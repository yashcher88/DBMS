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
        public void LoadFromJson(JsonArray J)
        {
            for (int i = 0; i < J.Count; i++) 
            { 
                DriverScript Script = new DriverScript();
                Script.LoadFromJson(J[i].AsObject());
                List.Add(Script);
            }
        }
        public JsonArray SaveToJson()
        {
            JsonArray J = new JsonArray();
            for (int i = 0; i < List.Count; i++) 
            { 
                J.Add(List[i].SaveToJson());
            }
            return J;
        }
    }
}
