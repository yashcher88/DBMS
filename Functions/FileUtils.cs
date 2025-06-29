using DBMS.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using Tmds.DBus.Protocol;

namespace DBMS.Functions
{
    static class FileUtils
    {
        public static Dictionary<string, string> GetFilesFromZip(string ZipPath, string StartFileName)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            if (File.Exists(ZipPath))
            {
                using var archive = ZipFile.OpenRead(ZipPath);
                foreach (var entry in archive.Entries)
                {
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
        public static string GetFileFromZip(string ZipPath, string StartFileName)
        {
            return GetFilesFromZip(ZipPath, StartFileName)[StartFileName];
        }
        public static void SaveFileToZip(string ZipPath, string FileName, string Content) {

            ZipArchiveMode mode = File.Exists(ZipPath) ? ZipArchiveMode.Update : ZipArchiveMode.Create;
            using (FileStream fileStream = new FileStream(ZipPath, FileMode.OpenOrCreate))
            using (ZipArchive archive = new ZipArchive(fileStream, mode))
            {
                ZipArchiveEntry existingEntry = archive.GetEntry(FileName);
                if (existingEntry != null) existingEntry.Delete();
                ZipArchiveEntry newEntry = archive.CreateEntry(FileName);
                using (StreamWriter writer = new StreamWriter(newEntry.Open()))
                {
                    writer.Write(Content);
                }
            }
        }

        public static void Log(string message, LogLevel level) {
            var timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            var fullMessage = $"[{timestamp}]    [{level}]    {message}";
            var dir = Path.Combine(AppContext.BaseDirectory, "log");
            var path = Path.Combine(dir, DateTime.Now.ToString("yyyy-MM-dd") + ".log");
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            File.AppendAllText(path, fullMessage + Environment.NewLine);
        }
        public static void Info(string message)
        {
            Log(message, LogLevel.Info);
        }
        public static void Error(string message)
        {
            Log(message, LogLevel.Error);
        }
        public static void Warning(string message)
        {
            Log(message, LogLevel.Warning);
        }
        public static void Debug(string message)
        {
            Log(message, LogLevel.Debug);
        }
    }
}
