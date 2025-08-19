using DBMS.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace DBMS.Classes
{
    public class ParameterLinkObjectLanguageDriverType : ParameterLinkObjectBase
    {
        string Path;
        public void LoadFromJson(JsonObject J)
        {
            Path = J["Path"].ToString();
        }
        public JsonObject SaveToJson()
        {
            JsonObject J = new JsonObject();
            J["Path"] = Path;
            return J;
        }
    }
}
