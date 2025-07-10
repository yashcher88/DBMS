using System;
using System.IO;

namespace DBMS.Classes
{
    public class Pathes
    {
        public string PackPath;
        public string SetsPath;
        public string ServersPath;

        public Pathes() {
            PackPath = AppContext.BaseDirectory + "pack.zip";
            var AppData = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "DatabaseManagementStudio"
            );
            Directory.CreateDirectory(AppData);
            SetsPath = Path.Combine(AppData, "sets.zip");
            ServersPath = Path.Combine(AppData, "servers.zip");
        }

    }
}
