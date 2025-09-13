using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json.Nodes;
using Avalonia.Controls;
using DBMS.Functions;

namespace DBMS.Classes
{
    public class Store
    {
        public BaseWindow Start = null;
        public BaseWindow Main = null;
        public Pathes Path = new Pathes();
        public LanguageObject LanguageObject = new LanguageObject();
        public int VersionPack = 0;
        public DriverList Drivers = new DriverList();
        public ServerList Servers = new ServerList();
        public UserStyle Style = new UserStyle();

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
            VersionPack = Convert.ToInt32(FileUtils.GetFileFromZip(Path.PackPath, "version") ?? "0");
        }
        public void SaveVersion()
        {
            VersionPack = VersionPack + 1;
            FileUtils.SaveFileToZip(Path.PackPath, "version", VersionPack.ToString());
        }
        public void LoadLanguage()
        {
            string Content = FileUtils.GetFileFromZip(Path.PackPath, "languages");
            if (Content != null)
            {
                var J = JsonNode.Parse(Content);
                LanguageObject.LoadObjectFromJson(J.AsObject());
            }
        }
        public void SaveLanguage()
        {
            FileUtils.SaveFileToZip(Path.PackPath, "languages", LanguageObject.SaveObjectToJson().ToString());
        }
        public void SavePack() 
        {
            SaveLanguage();
            SaveVersion();
        }
        public void SaveServers()
        {
            FileUtils.SaveFileToZip(Path.ServersPath, "servers", Servers.SaveObjectToJson().ToString());
        }
        public void LoadServers()
        {
            string Content = FileUtils.GetFileFromZip(Path.ServersPath, "servers");
            if (Content != null)
            {
                var J = JsonNode.Parse(Content);
                Servers.LoadObjectFromJson(J.AsArray());
            }
        }
    }
}
