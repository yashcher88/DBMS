using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace DBMS.Classes
{
    public class DriverScriptList
    {
        public List<DriverScript> List = new List<DriverScript>();
        public void LoadDriverScriptListFromJson(JsonArray J)
        {
            for (int i = 0; i < J.Count; i++) 
            { 
                DriverScript Script = new DriverScript();
                Script.LoadDriverScriptFromJson(J[i].AsObject());
                List.Add(Script);
            }
        }
        public JsonArray SaveDriverScriptListToJson()
        {
            JsonArray J = new JsonArray();
            for (int i = 0; i < List.Count; i++) 
            { 
                J.Add(List[i].SaveDriverScriptToJson());
            }
            return J;
        }
    }
}
