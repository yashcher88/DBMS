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
    public class ParameterLinkType
    {
        public ScriptLinkParameterType ParameterType;
        public ParameterLinkObjectBase Value;
        public void LoadFromJson(JsonObject J)
        {
            ParameterType = CConvert.StringToScriptLinkParameterType(J["ParameterType"].ToString());
            switch (ParameterType)
            {
                case ScriptLinkParameterType.StringType:
                    Value = new ParameterLinkObjectString();
                    (Value as ParameterLinkObjectString).LoadFromJson(J["Value"].AsObject());
                    break;
                case ScriptLinkParameterType.ObjectExplorerNodeType:
                    Value = new ParameterLinkObjectObjectExplorerNode();
                    (Value as ParameterLinkObjectObjectExplorerNode).LoadFromJson(J["Value"].AsObject());
                    break;
                case ScriptLinkParameterType.ObjectExplorerLevelType:
                    Value = new ParameterLinkObjectObjectExplorerNode();
                    (Value as ParameterLinkObjectObjectExplorerNode).LoadFromJson(J["Value"].AsObject());
                    break;
                case ScriptLinkParameterType.SettingType:
                    Value = new ParameterLinkObjectSettingType();
                    (Value as ParameterLinkObjectSettingType).LoadFromJson(J["Value"].AsObject());
                    break;
                case ScriptLinkParameterType.LanguageType:
                    Value = new ParameterLinkObjectLanguageType();
                    (Value as ParameterLinkObjectLanguageType).LoadFromJson(J["Value"].AsObject());
                    break;
                case ScriptLinkParameterType.LanguageDriverType:
                    Value = new ParameterLinkObjectLanguageType();
                    (Value as ParameterLinkObjectLanguageDriverType).LoadFromJson(J["Value"].AsObject());
                    break;
            }
        }
        public JsonObject SaveToJson()
        {
            JsonObject J = new JsonObject();
            J["ParameterType"] = CConvert.ScriptLinkParameterTypeToString(ParameterType);
            switch (ParameterType)
            {
                case ScriptLinkParameterType.StringType:
                    J["Value"] = (Value as ParameterLinkObjectString).SaveToJson();
                    break;
                case ScriptLinkParameterType.ObjectExplorerNodeType:
                    J["Value"] = (Value as ParameterLinkObjectObjectExplorerNode).SaveToJson();
                    break;
                case ScriptLinkParameterType.ObjectExplorerLevelType:
                    J["Value"] = (Value as ParameterLinkObjectObjectExplorerNode).SaveToJson();
                    break;
                case ScriptLinkParameterType.SettingType:
                    J["Value"] = (Value as ParameterLinkObjectSettingType).SaveToJson();
                    break;
                case ScriptLinkParameterType.LanguageType:
                    J["Value"] = (Value as ParameterLinkObjectLanguageType).SaveToJson();
                    break;
                case ScriptLinkParameterType.LanguageDriverType:
                    J["Value"] = (Value as ParameterLinkObjectLanguageDriverType).SaveToJson();
                    break;
            }
            return J;
        }
    }
}
