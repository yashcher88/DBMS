using DBMS.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace DBMS.Classes
{
    public class ScriptLinkObjectLanguageType : ScriptLinkObjectBase
    {
        string Path;
        public void LoadScriptLinkObjectLanguageTypeFromJson(JsonObject J)
        {
            Path = J["Path"].ToString();
        }
        public JsonObject SaveScriptLinkObjectLanguageTypeToJson()
        {
            JsonObject J = new JsonObject();
            J["Path"] = Path;
            return J;
        }
    }
}
