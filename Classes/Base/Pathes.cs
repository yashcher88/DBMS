using System;
using System.IO;

namespace DBMS.Classes
{
    public class Pathes
    {
        public string PackPath;
        public string SetsPath;
        public string ServersPath;
        public string SqlSaveDir;
        public string SqlHistorySaveDir;

        public Pathes() {
            PackPath = AppContext.BaseDirectory + "pack.zip";
            var AppData = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "DatabaseManagementStudio"
            );
            SetsPath = Path.Combine(AppData, "sets.zip");
            ServersPath = Path.Combine(AppData, "servers.zip");
            SqlSaveDir = Path.Combine(AppData, "SQLfiles");
            SqlHistorySaveDir = Path.Combine(AppData, "History");
            Directory.CreateDirectory(AppData);
            Directory.CreateDirectory(SqlSaveDir);
            Directory.CreateDirectory(SqlHistorySaveDir);
        }
    }
}
