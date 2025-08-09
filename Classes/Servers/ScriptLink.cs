using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace DBMS.Classes
{
    public class ScriptLink
    {
        public string ScriptPath;
        public List<ScriptLinkParameter> Params = new List<ScriptLinkParameter>();
        public ScriptLink(string path, JsonArray JA)
        {
            ScriptPath = path;
            if (JA != null) 
            {
                for (var i = 0; i < JA.Count; i++) 
                {
                    //Params.Add(JA[i].ToString());
                }
            }
        }
        public void LoadScriptLinkFromJson(JsonObject J)
        {

        }
        public void SaveScriptLinkToJson(JsonObject J)
        {

        }
    }
}
