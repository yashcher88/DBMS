using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json.Nodes;
using Avalonia.Controls;
using DBMS.Classes.Language;
using DBMS.Classes.Language.Old;
using DBMS.Functions;

namespace DBMS.Classes
{
    public class Store
    {
        public BaseForm Start = null;
        private string PackPath;
        private string SetsPath;
        private string ServersPath;

        public LanguageObject LanguageObject;
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
        public void LoadLanguages()
        {
            string Content = FileUtils.GetFileFromZip(PackPath, "languages");
            if (Content != null) {
                Languages.Clear();
                var J = JsonNode.Parse(Content).AsObject();
                foreach (var item in J.AsObject()) {
                    var Lang = new UserLanguage();
                    Lang.LoadFromJson(item.Value.AsObject());
                    Languages.Add(item.Key, Lang);
                }
            }
        }
        public void SaveLanguages() { 
            JsonNode J = new JsonObject();
            foreach (var language in Languages)
            {
                J[language.Key] = language.Value.SaveToJson();
            }
            FileUtils.SaveFileToZip(PackPath, "languages", J.ToString());
        }
        public void LanguageLoadFromWindow(Window W) {
            foreach (var node in Languages) {
                node.Value.LoadFromWindow(W);
            }
        }
    }
}
