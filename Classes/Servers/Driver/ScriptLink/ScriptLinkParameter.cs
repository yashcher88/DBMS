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
        public ScriptLinkObjectBase Value;

        public void LoadScriptLinkParameterFromJson(JsonObject J)
        {
            ParameterType = CConvert.StringToScriptLinkParameterType(J["ParameterType"].ToString());
            switch (ParameterType)
            {
                case ScriptLinkParameterType.StringType:
                    Value = new ScriptLinkObjectString();
                    (Value as ScriptLinkObjectString).LoadScriptLinkObjectStringFromJson(J["Value"].AsObject());
                    break;
                case ScriptLinkParameterType.ObjectExplorerNodeType:
                    Value = new ScriptLinkObjectObjectExplorerNode();
                    (Value as ScriptLinkObjectObjectExplorerNode).LoadScriptLinkObjectObjectExplorerNodeFromJson(J["Value"].AsObject());
                    break;
            }
        }
        public JsonObject SaveScriptLinkParameterToJson()
        {
            JsonObject J = new JsonObject();
            J["ParameterType"] = CConvert.ScriptLinkParameterTypeToString(ParameterType);
            return J;
        }
    }
}
