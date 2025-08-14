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
        Dictionary<string, DriverScriptList> ScriptDictionary = new Dictionary<string, DriverScriptList>();

        public void LoadDriverScriptDictionaryFromJson(JsonObject J) 
        {
            foreach (var node in J)
            {
                DriverScriptList script = new DriverScriptList();
                script.LoadDriverScriptListFromJson(node.Value.AsArray());
                ScriptDictionary.Add(node.Key, script);
            }
        }
        public JsonObject SaveDriverScriptDictionaryFromJson() 
        { 
            JsonObject J = new JsonObject();
            foreach (var node in ScriptDictionary)
            {
                J[node.Key] = node.Value.SaveDriverScriptListToJson();
            }
            return J;
        }

    }
}
