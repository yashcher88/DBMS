using Avalonia.Controls;
using Avalonia.Markup.Xaml.Templates;
using HarfBuzzSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace DBMS.Classes
{
    public class Driver
    {
        public DriverInfo Info;
        public Dictionary<string, DriverPopup> Popups = new Dictionary<string, DriverPopup>();
        public Dictionary<string, DriverLanguage> Languages = new Dictionary<string, DriverLanguage>();
        public Dictionary<string, DriverScript> Scripts = new Dictionary<string, DriverScript>();
        public Dictionary<string, DriverForm> Forms = new Dictionary<string, DriverForm>();
        public Dictionary<string, DriverScriptTemplate> Templates = new Dictionary<string, DriverScriptTemplate>();

        public string Name;
        public string DriverType;
        public Driver(string _name) 
        {
            Name = _name;
        }
        public void LoadDriverFromZip(JsonObject J) 
        { 
            
        }
        public JsonObject SaveDriverToZip()
        {
            JsonObject J = new JsonObject();

            return J;
        }
    }
}
