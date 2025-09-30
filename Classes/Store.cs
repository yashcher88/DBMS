using Avalonia.Media.Imaging;
using Avalonia.Platform;
using DBMS.Functions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.Json.Nodes;

namespace DBMS.Classes
{
    public class Store
    {
        /* Настройки, Перевод */
        public SettingObject Sets = new SettingObject();
        public BaseWindow Start = null;
        public BaseWindow Main = null;
        public int VersionPack = 0;
        public DriverList Drivers = new DriverList();
        public ServerList Servers = new ServerList();
        public Dictionary<string,Bitmap> Images = new Dictionary<string,Bitmap>();
        public LanguageObject Lang { get { return Sets.Language; } }
        public StyleObject Style { get { return Sets.Style; } }
        public Store() 
        {
            AddDriver("PostgreSQL");
            AddDriver("MySQL");
        }
        public void AddDriver(string DriverName) 
        {
            var M = new Driver(DriverName);
            Drivers.List.Add(DriverName,M);
        }

        public string GetUserVersion() {
            int Vers = Convert.ToInt32(VersionPack);
            return (Vers / 10000).ToString() + "." + (Vers / 100).ToString() + "." + (Vers % 100).ToString();
        }
        public void LoadVersion()
        {
            VersionPack = Convert.ToInt32(FileUtils.GetFileFromZip(Sets.SystemPath.PackPath, "version") ?? "0");
        }
        public void SaveVersion()
        {
            VersionPack = VersionPack + 1;
            FileUtils.SaveFileToZip(Sets.SystemPath.PackPath, "version", VersionPack.ToString());
        }
        public void LoadSystemSettings()
        {
            string Content = FileUtils.GetFileFromZip(Sets.SystemPath.PackPath, "settings");
            if (Content != null)
            {
                var J = JsonNode.Parse(Content);
                Sets.LoadSystemFromJson(J.AsObject());
            }
        }
        public void SaveSystemSettings()
        {
            FileUtils.SaveFileToZip(Sets.SystemPath.PackPath, "settings", Sets.SaveSystemToJson().ToString());
        }
        public void LoadUserSettings()
        {
            string Content = FileUtils.GetFileFromZip(Sets.SystemPath.SetsPath, "settings");
            if (Content != null)
            {
                var J = JsonNode.Parse(Content);
                Sets.LoadUserFromJson(J.AsObject());
            }
        }
        public void SaveUserSettings()
        {
            FileUtils.SaveFileToZip(Sets.SystemPath.SetsPath, "settings", Sets.SaveUserToJson().ToString());
        }
        public void SavePack() 
        {
            SaveSystemSettings();
            SaveVersion();
        }
        public void SaveServers()
        {
            FileUtils.SaveFileToZip(Sets.SystemPath.ServersPath, "servers", Servers.SaveObjectToJson().ToString());
        }
        public void LoadServers()
        {
            string Content = FileUtils.GetFileFromZip(Sets.SystemPath.ServersPath, "servers");
            if (Content != null)
            {
                var J = JsonNode.Parse(Content);
                Servers.LoadObjectFromJson(J.AsArray());
            }
        }
        public void LoadImages() 
        {
            Images.Add("ButtonIcons.Connect", new Bitmap(AssetLoader.Open(new Uri("avares://DBMS/Sources/ButtonIcons/Connect.png"))));
            Images.Add("ButtonIcons.Disconnect", new Bitmap(AssetLoader.Open(new Uri("avares://DBMS/Sources/ButtonIcons/Disconnect.png"))));
            Images.Add("StateIcons.Complete", new Bitmap(AssetLoader.Open(new Uri("avares://DBMS/Sources/StateIcons/Complete.png"))));
            Images.Add("StateIcons.CompleteError", new Bitmap(AssetLoader.Open(new Uri("avares://DBMS/Sources/StateIcons/CompleteError.png"))));
            Images.Add("StateIcons.Canceled", new Bitmap(AssetLoader.Open(new Uri("avares://DBMS/Sources/StateIcons/Canceled.png"))));
            Images.Add("StateIcons.Executing.0", new Bitmap(AssetLoader.Open(new Uri("avares://DBMS/Sources/StateIcons/Executing/0.png"))));
            Images.Add("StateIcons.Executing.1", new Bitmap(AssetLoader.Open(new Uri("avares://DBMS/Sources/StateIcons/Executing/1.png"))));
            Images.Add("StateIcons.Executing.2", new Bitmap(AssetLoader.Open(new Uri("avares://DBMS/Sources/StateIcons/Executing/2.png"))));
            Images.Add("StateIcons.Executing.3", new Bitmap(AssetLoader.Open(new Uri("avares://DBMS/Sources/StateIcons/Executing/3.png"))));
            Images.Add("StateIcons.Executing.4", new Bitmap(AssetLoader.Open(new Uri("avares://DBMS/Sources/StateIcons/Executing/4.png"))));
            Images.Add("StateIcons.Executing.5", new Bitmap(AssetLoader.Open(new Uri("avares://DBMS/Sources/StateIcons/Executing/5.png"))));
            Images.Add("StateIcons.Executing.6", new Bitmap(AssetLoader.Open(new Uri("avares://DBMS/Sources/StateIcons/Executing/6.png"))));
            Images.Add("StateIcons.Executing.7", new Bitmap(AssetLoader.Open(new Uri("avares://DBMS/Sources/StateIcons/Executing/7.png"))));
            Images.Add("StateIcons.Executing.8", new Bitmap(AssetLoader.Open(new Uri("avares://DBMS/Sources/StateIcons/Executing/8.png"))));
            Images.Add("StateIcons.Executing.9", new Bitmap(AssetLoader.Open(new Uri("avares://DBMS/Sources/StateIcons/Executing/9.png"))));
        }
    }
}
