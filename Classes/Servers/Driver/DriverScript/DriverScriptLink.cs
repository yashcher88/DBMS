using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace DBMS.Classes
{
    public class DriverScriptLink
    {
        public string ScriptPath;
        public List<ParameterLinkType> Params = new List<ParameterLinkType>();
        public void LoadFromJson(JsonObject J)
        {
            ScriptPath = J["ScriptPath"].ToString();
            Params.Clear();
            for (var i = 0; i < J["Params"].AsArray().Count(); i++)
            { 
                var P = new ParameterLinkType();
                P.LoadFromJson(J["Params"][i].AsObject());
                Params.Add(P);
            }
        }
        public JsonObject SaveToJson()
        {
            var J = new JsonObject();
            J["ScriptPath"] = ScriptPath;
            J["Params"] = new JsonArray();
            for (var i = 0; i < Params.Count; i++) 
            {
                J["Params"].AsArray().Add(Params[i].SaveToJson());
            }
            return J;
        }
    }
}
