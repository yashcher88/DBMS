using DBMS.Classes;
using DBMS.Enums;
using System.Text.Json.Nodes;

namespace DBMS.Functions
{
    static class CConvert
    {
        public static string UserControlTypeToString(UserControlType CType) {
            switch (CType) {
                case UserControlType.Window: return "Window";
                case UserControlType.MenuItem: return "MenuItem";
                case UserControlType.TabItem: return "TabItem";
                case UserControlType.Button: return "Button";
                case UserControlType.TextBlock: return "TextBlock";
                case UserControlType.TextBox: return "TextBox";
                default: return "";
            }
        }
        public static UserControlType StringToUserControlType(string SType)
        {
            switch (SType)
            {
                case "Window": return UserControlType.Window;
                case "MenuItem": return UserControlType.MenuItem;
                case "TabItem": return UserControlType.TabItem;
                case "Button": return UserControlType.Button;
                case "TextBlock": return UserControlType.TextBlock;
                case "TextBox": return UserControlType.TextBox;
                default: return UserControlType.TextBox;
            }
        }
        public static JsonArray UserControlPropertyToArray(UserControlProperty P)
        {
            JsonArray J = new JsonArray();
            if (P.HasFlag(UserControlProperty.Text)) { J.Add("Text"); }
            if (P.HasFlag(UserControlProperty.Content)) { J.Add("Content"); }
            if (P.HasFlag(UserControlProperty.Title)) { J.Add("Title"); }
            if (P.HasFlag(UserControlProperty.ToolTip)) { J.Add("ToolTip"); }
            if (P.HasFlag(UserControlProperty.Header)) { J.Add("Header"); }
            if (P.HasFlag(UserControlProperty.WaterMark)) { J.Add("WaterMark"); }
            return J;
        }
        public static UserControlProperty ArrayToUserControlProperty(JsonArray J)
        {
            UserControlProperty P = 0;
            for (var i = 0; i < J.Count; i++) 
            {
                switch (J[i].ToString()) { 
                    case "Text": P = P | UserControlProperty.Text; break;
                    case "Content": P = P | UserControlProperty.Content; break;
                    case "Title": P = P | UserControlProperty.Title; break;
                    case "ToolTip": P = P | UserControlProperty.ToolTip; break;
                    case "Header": P = P | UserControlProperty.Header; break;
                    case "WaterMark": P = P | UserControlProperty.WaterMark; break;
                }
            }
            return P;
        }
        public static string ScriptLinkParameterTypeToString(ScriptLinkParameterType CType)
        {
            switch (CType)
            {
                case ScriptLinkParameterType.StringType: return "StringType";
                case ScriptLinkParameterType.ObjectExplorerNodeType: return "ObjectExplorerNodeType";
                case ScriptLinkParameterType.ObjectExplorerLevelType: return "ObjectExplorerLevelType";
                case ScriptLinkParameterType.SettingType: return "SettingType";
                case ScriptLinkParameterType.LanguageType: return "LanguageType";
                default: return "";
            }
        }
        public static ScriptLinkParameterType StringToScriptLinkParameterType(string SType)
        {
            switch (SType)
            {
                case "StringType": return ScriptLinkParameterType.StringType;
                case "ObjectExplorerNodeType": return ScriptLinkParameterType.ObjectExplorerNodeType;
                case "ObjectExplorerLevelType": return ScriptLinkParameterType.ObjectExplorerLevelType;
                case "SettingType": return ScriptLinkParameterType.SettingType;
                case "LanguageType": return ScriptLinkParameterType.LanguageType;
                default: return ScriptLinkParameterType.StringType;
            }
        }
        public static string ObjectExplorerNodeTypeToString(ObjectExplorerNodeType CType)
        {
            switch (CType)
            {
                case ObjectExplorerNodeType.Unknown: return "Unknown";
                case ObjectExplorerNodeType.Server: return "Server";
                case ObjectExplorerNodeType.Database: return "Database";
                case ObjectExplorerNodeType.Scheme: return "Scheme";
                case ObjectExplorerNodeType.Table: return "Table";
                case ObjectExplorerNodeType.Column: return "Column";
                case ObjectExplorerNodeType.HashIndex: return "HashIndex";
                case ObjectExplorerNodeType.BTreeIndex: return "BTreeIndex";
                case ObjectExplorerNodeType.Procedure: return "Procedure";
                case ObjectExplorerNodeType.ScalarFunction: return "ScalarFunction";
                case ObjectExplorerNodeType.TableFunction: return "TableFunction";
                case ObjectExplorerNodeType.FunctionResult: return "FunctionResult";
                case ObjectExplorerNodeType.FunctionParameter: return "FunctionParameter";
                case ObjectExplorerNodeType.View: return "View";
                default: return "Unknown";
            }
        }
        public static ObjectExplorerNodeType StringToObjectExplorerNodeType(string SType)
        {
            switch (SType)
            {
                case "Unknown" : return ObjectExplorerNodeType.Unknown;
                case "Server" : return ObjectExplorerNodeType.Server;
                case "Database" : return ObjectExplorerNodeType.Database;
                case "Scheme" : return ObjectExplorerNodeType.Scheme;
                case "Table" : return ObjectExplorerNodeType.Table;
                case "Column" : return ObjectExplorerNodeType.Column;
                case "HashIndex" : return ObjectExplorerNodeType.HashIndex;
                case "BTreeIndex" : return ObjectExplorerNodeType.BTreeIndex;
                case "Procedure" : return ObjectExplorerNodeType.Procedure;
                case "ScalarFunction" : return ObjectExplorerNodeType.ScalarFunction;
                case "TableFunction" : return ObjectExplorerNodeType.TableFunction;
                case "FunctionResult" : return ObjectExplorerNodeType.FunctionResult;
                case "FunctionParameter" : return ObjectExplorerNodeType.FunctionParameter;
                case "View" : return ObjectExplorerNodeType.View;
                default: return ObjectExplorerNodeType.Unknown;
            }
        }
    }
}
