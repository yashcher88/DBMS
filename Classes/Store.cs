using System;
using System.Collections.Generic;
using System.IO;
using DBMS.Functions;

namespace DBMS.Classes
{
    public class Store
    {
        private string PackPath;
        private string SetsPath;
        private string ServersPath;
        
        public Dictionary<string,UserLanguage> Languages = new Dictionary<string,UserLanguage>();
        public string VersionPack = "0";

        public string GetUserVersion() {
            int Vers = Convert.ToInt32(VersionPack);
            return (Vers / 10000).ToString() + "."+ (Vers / 100).ToString() + "." + (Vers % 100).ToString();
        }
        public Store() {
            PackPath = AppContext.BaseDirectory + "pack.zip";
            var AppData = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "DatabaseManagementStudio"
            );
            Directory.CreateDirectory(AppData);
            SetsPath = Path.Combine(AppData, "sets.zip");
            ServersPath = Path.Combine(AppData, "servers.zip");
            //Добавляем дефолтный язык
            Languages.Add("Русский", new UserLanguage());
        }
        public void LoadVersion()
        {
            VersionPack = FileUtils.GetFileFromZip(PackPath, "version") ?? "0";
        }
        public void SaveVersion()
        {
            VersionPack = (Convert.ToInt32(VersionPack) + 1).ToString();
            FileUtils.SaveFileToZip(PackPath, "version", VersionPack.ToString());
        }
        public void LoadLanguage()
        {
            string Content = FileUtils.GetFileFromZip(PackPath, "language");
            if (Content != null) { 
                
            }
        }
        public void SaveLanguage() { 
            
        }
    }
}
