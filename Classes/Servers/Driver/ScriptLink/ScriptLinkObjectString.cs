using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace DBMS.Classes
{
    public class ScriptLinkObjectString : ScriptLinkObjectBase
    {
        string Value;

        public void LoadScriptLinkObjectStringFromJson(JsonObject J)
        {
            Value = J["Value"].ToString();
        }
        public JsonObject SaveScriptLinkObjectStringToJson()
        {
            JsonObject J = new JsonObject();
            J["Value"] = Value;
            return J;
        }
    }
}
