using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace DBMS.Classes.Servers.Driver.ScriptLink
{
    public class ScriptLinkObjectSettingType : ScriptLinkObjectBase
    {
        string Path;
        public void LoadScriptLinkObjectSettingTypeFromJson(JsonObject J)
        {
            Path = J["Path"].ToString();
        }
        public JsonObject SaveScriptLinkObjectSettingTypeToJson()
        {
            JsonObject J = new JsonObject();
            J["Path"] = Path;
            return J;
        }
    }
}
