using DBMS.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using DBMS.Functions;
using DBMS.Classes.Servers.Driver.ScriptLink;

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
                case ScriptLinkParameterType.ObjectExplorerLevelType:
                    Value = new ScriptLinkObjectObjectExplorerNode();
                    (Value as ScriptLinkObjectObjectExplorerNode).LoadScriptLinkObjectObjectExplorerNodeFromJson(J["Value"].AsObject());
                    break;
                case ScriptLinkParameterType.SettingType:
                    Value = new ScriptLinkObjectSettingType();
                    (Value as ScriptLinkObjectSettingType).LoadScriptLinkObjectSettingTypeFromJson(J["Value"].AsObject());
                    break;
                case ScriptLinkParameterType.LanguageType:
                    Value = new ScriptLinkObjectLanguageType();
                    (Value as ScriptLinkObjectLanguageType).LoadScriptLinkObjectLanguageTypeFromJson(J["Value"].AsObject());
                    break;
            }
        }
        public JsonObject SaveScriptLinkParameterToJson()
        {
            JsonObject J = new JsonObject();
            J["ParameterType"] = CConvert.ScriptLinkParameterTypeToString(ParameterType);
            switch (ParameterType)
            {
                case ScriptLinkParameterType.StringType:
                    J["Value"] = (Value as ScriptLinkObjectString).SaveScriptLinkObjectStringToJson();
                    break;
                case ScriptLinkParameterType.ObjectExplorerNodeType:
                    J["Value"] = (Value as ScriptLinkObjectObjectExplorerNode).SaveScriptLinkObjectObjectExplorerNodeToJson();
                    break;
                case ScriptLinkParameterType.ObjectExplorerLevelType:
                    J["Value"] = (Value as ScriptLinkObjectObjectExplorerNode).SaveScriptLinkObjectObjectExplorerNodeToJson();
                    break;
                case ScriptLinkParameterType.SettingType:
                    J["Value"] = (Value as ScriptLinkObjectSettingType).SaveScriptLinkObjectSettingTypeToJson();
                    break;
                case ScriptLinkParameterType.LanguageType:
                    J["Value"] = (Value as ScriptLinkObjectLanguageType).SaveScriptLinkObjectLanguageTypeToJson();
                    break;
            }
            return J;
        }
    }
}
