using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace DBMS.Classes
{
    public class ScriptLinkObjectObjectExplorerNode : ScriptLinkObjectBase
    {
        int Level;
        string ParameterName;

        public void LoadScriptLinkObjectObjectExplorerNodeFromJson(JsonObject J)
        {
            Level = Convert.ToInt32(J["Level"].ToString());
            ParameterName = J["ParameterName"].ToString();
        }
        public JsonObject SaveScriptLinkObjectObjectExplorerNodeToJson()
        {
            JsonObject J = new JsonObject();
            J["Level"] = Level;
            J["ParameterName"] = ParameterName;
            return J;
        }
    }
}
