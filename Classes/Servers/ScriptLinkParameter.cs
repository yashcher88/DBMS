using DBMS.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using DBMS.Functions;

namespace DBMS.Classes
{
    public class ScriptLinkParameter
    {
        public ScriptLinkParameterType ParameterType;
        public object Value;

        public void LoadScriptLinkParameterFromJson(JsonObject J)
        {
            ParameterType = CConvert.StringToScriptLinkParameterType(J["ParameterType"].ToString());
        }
        public JsonObject SaveScriptLinkParameterToJson()
        {
            JsonObject J = new JsonObject();
            J["ParameterType"] = CConvert.ScriptLinkParameterTypeToString(ParameterType);
            return J;
        }
    }
}
