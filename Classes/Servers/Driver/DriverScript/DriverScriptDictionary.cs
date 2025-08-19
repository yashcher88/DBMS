using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace DBMS.Classes
{
    public class DriverScriptDictionary
    {
        Dictionary<string, DriverScriptList> Dictionary = new Dictionary<string, DriverScriptList>();

        public void LoadFromJson(JsonObject J) 
        {
            foreach (var node in J)
            {
                DriverScriptList script = new DriverScriptList();
                script.LoadFromJson(node.Value.AsArray());
                Dictionary.Add(node.Key, script);
            }
        }
        public JsonObject SaveFromJson() 
        { 
            JsonObject J = new JsonObject();
            foreach (var node in Dictionary)
            {
                J[node.Key] = node.Value.SaveToJson();
            }
            return J;
        }

    }
}
