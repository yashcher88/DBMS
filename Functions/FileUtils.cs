using System.IO;
using System.IO.Compression;
using System.Collections.Generic;

namespace DBMS.Functions
{
    static class FileUtils
    {
        public static Dictionary<string,string> GetFileFromZip(string ZipPath, string StartFileName)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            if (File.Exists(ZipPath))
            {
                using var archive = ZipFile.OpenRead(ZipPath);
                foreach (var entry in archive.Entries) {
                    using var stream = entry.Open();
                    using var reader = new StreamReader(stream);
                    string content = reader.ReadToEnd();
                    if (entry.FullName.StartsWith(StartFileName))
                    {
                        result.Add(entry.FullName, content);
                    }
                }
            }
            return result;
        }
        public static void SaveFileToZip(string ZipPath, string FileName, string Content) {

        }
    }
}
