using Avalonia.Controls;
using Avalonia.Media;
using DBMS.Classes;
using DBMS.Enums;
using HarfBuzzSharp;
using System;
using System.Data;
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
        public static string ObjectExplorerNodeTypeToString(ObjectTreeNodeType CType)
        {
            switch (CType)
            {
                case ObjectTreeNodeType.Unknown: return "Unknown";
                case ObjectTreeNodeType.Server: return "Server";
                case ObjectTreeNodeType.Database: return "Database";
                case ObjectTreeNodeType.Scheme: return "Scheme";
                case ObjectTreeNodeType.Table: return "Table";
                case ObjectTreeNodeType.Column: return "Column";
                case ObjectTreeNodeType.HashIndex: return "HashIndex";
                case ObjectTreeNodeType.BTreeIndex: return "BTreeIndex";
                case ObjectTreeNodeType.Procedure: return "Procedure";
                case ObjectTreeNodeType.ScalarFunction: return "ScalarFunction";
                case ObjectTreeNodeType.TableFunction: return "TableFunction";
                case ObjectTreeNodeType.FunctionResult: return "FunctionResult";
                case ObjectTreeNodeType.FunctionParameter: return "FunctionParameter";
                case ObjectTreeNodeType.View: return "View";
                default: return "Unknown";
            }
        }
        public static ObjectTreeNodeType StringToObjectExplorerNodeType(string SType)
        {
            switch (SType)
            {
                case "Unknown": return ObjectTreeNodeType.Unknown;
                case "Server": return ObjectTreeNodeType.Server;
                case "Database": return ObjectTreeNodeType.Database;
                case "Scheme": return ObjectTreeNodeType.Scheme;
                case "Table": return ObjectTreeNodeType.Table;
                case "Column": return ObjectTreeNodeType.Column;
                case "HashIndex": return ObjectTreeNodeType.HashIndex;
                case "BTreeIndex": return ObjectTreeNodeType.BTreeIndex;
                case "Procedure": return ObjectTreeNodeType.Procedure;
                case "ScalarFunction": return ObjectTreeNodeType.ScalarFunction;
                case "TableFunction": return ObjectTreeNodeType.TableFunction;
                case "FunctionResult": return ObjectTreeNodeType.FunctionResult;
                case "FunctionParameter": return ObjectTreeNodeType.FunctionParameter;
                case "View": return ObjectTreeNodeType.View;
                default: return ObjectTreeNodeType.Unknown;
            }
        }
        public static ObjectTreeImage StringToObjectTreeImage(string SType)
        {
            switch (SType)
            {
                case "Server": return ObjectTreeImage.Server;
                case "Folder": return ObjectTreeImage.Folder;
                case "Database": return ObjectTreeImage.Database;
                case "Table": return ObjectTreeImage.Table;
                case "Column": return ObjectTreeImage.Column;
                case "View": return ObjectTreeImage.View;
                case "TableFunction": return ObjectTreeImage.TableFunction;
                case "TableFunctionC": return ObjectTreeImage.TableFunctionC;
                case "ColumnPrimary": return ObjectTreeImage.ColumnPrimary;
                case "ColumnForeign": return ObjectTreeImage.ColumnForeign;
                case "PrimaryKey": return ObjectTreeImage.PrimaryKey;
                case "ForeignKey": return ObjectTreeImage.ForeignKey;
                case "Constraint": return ObjectTreeImage.Constraint;
                case "IndexBtree": return ObjectTreeImage.IndexBtree;
                case "IndexGin": return ObjectTreeImage.IndexGin;
                case "Statistic": return ObjectTreeImage.Statistic;
                case "Sequence": return ObjectTreeImage.Sequence;
                case "EnableTrigger": return ObjectTreeImage.EnableTrigger;
                case "DisableTrigger": return ObjectTreeImage.DisableTrigger;
                case "InParameter": return ObjectTreeImage.InParameter;
                case "InOutParameter": return ObjectTreeImage.InOutParameter;
                case "OutParameter": return ObjectTreeImage.OutParameter;
                case "TableParameter": return ObjectTreeImage.TableParameter;
                case "Procedure": return ObjectTreeImage.Procedure;
                case "ProcedureC": return ObjectTreeImage.ProcedureC;
                case "ScalarFunction": return ObjectTreeImage.ScalarFunction;
                case "ScalarFunctionC": return ObjectTreeImage.ScalarFunctionC;
                case "ExtensionDisable": return ObjectTreeImage.ExtensionDisable;
                case "ExtensionEnable": return ObjectTreeImage.ExtensionEnable;
                case "ExtensionUpgradable": return ObjectTreeImage.ExtensionUpgradable;
                case "Type": return ObjectTreeImage.Type;
                case "Scheme": return ObjectTreeImage.Scheme;
                case "User": return ObjectTreeImage.User;
                case "Role": return ObjectTreeImage.Role;
                case "ViewMatherial": return ObjectTreeImage.ViewMatherial;
                case "Rule": return ObjectTreeImage.Rule;
                case "Policy": return ObjectTreeImage.Policy;
                case "Language": return ObjectTreeImage.Language;
                case "TableSecurity": return ObjectTreeImage.TableSecurity;
                case "ForeignServer": return ObjectTreeImage.ForeignServer;
                case "DatabaseInactive": return ObjectTreeImage.DatabaseInactive;
                case "TableSpace": return ObjectTreeImage.TableSpace;
                case "TablePartition": return ObjectTreeImage.TablePartition;
                default: return ObjectTreeImage.Folder;
            }
        }
        public static string ObjectTreeImageToString(ObjectTreeImage CType)
        {
            switch (CType)
            {
                case ObjectTreeImage.Server : return "Server";
                case ObjectTreeImage.Folder : return "Folder";
                case ObjectTreeImage.Database : return "Database";
                case ObjectTreeImage.Table : return "Table";
                case ObjectTreeImage.Column : return "Column";
                case ObjectTreeImage.View : return "View";
                case ObjectTreeImage.TableFunction : return "TableFunction";
                case ObjectTreeImage.TableFunctionC : return "TableFunctionC";
                case ObjectTreeImage.ColumnPrimary : return "ColumnPrimary";
                case ObjectTreeImage.ColumnForeign : return "ColumnForeign";
                case ObjectTreeImage.PrimaryKey : return "PrimaryKey";
                case ObjectTreeImage.ForeignKey : return "ForeignKey";
                case ObjectTreeImage.Constraint : return "Constraint";
                case ObjectTreeImage.IndexBtree : return "IndexBtree";
                case ObjectTreeImage.IndexGin : return "IndexGin";
                case ObjectTreeImage.Statistic : return "Statistic";
                case ObjectTreeImage.Sequence : return "Sequence";
                case ObjectTreeImage.EnableTrigger: return "EnableTrigger";
                case ObjectTreeImage.DisableTrigger: return "DisableTrigger";
                case ObjectTreeImage.InParameter: return "InParameter";
                case ObjectTreeImage.InOutParameter: return "InOutParameter";
                case ObjectTreeImage.OutParameter: return "OutParameter";
                case ObjectTreeImage.TableParameter: return "TableParameter";
                case ObjectTreeImage.Procedure: return "Procedure";
                case ObjectTreeImage.ProcedureC: return "ProcedureC";
                case ObjectTreeImage.ScalarFunction: return "ScalarFunction";
                case ObjectTreeImage.ScalarFunctionC: return "ScalarFunctionC";
                case ObjectTreeImage.ExtensionDisable: return "ExtensionDisable";
                case ObjectTreeImage.ExtensionEnable: return "ExtensionEnable";
                case ObjectTreeImage.ExtensionUpgradable: return "ExtensionUpgradable";
                case ObjectTreeImage.Type: return "Type";
                case ObjectTreeImage.Scheme: return "Scheme";
                case ObjectTreeImage.User: return "User";
                case ObjectTreeImage.Role: return "Role";
                case ObjectTreeImage.ViewMatherial: return "ViewMatherial";
                case ObjectTreeImage.Rule: return "Rule";
                case ObjectTreeImage.Policy: return "Policy";
                case ObjectTreeImage.Language: return "Language";
                case ObjectTreeImage.TableSecurity: return "TableSecurity";
                case ObjectTreeImage.ForeignServer: return "ForeignServer";
                case ObjectTreeImage.DatabaseInactive: return "DatabaseInactive";
                case ObjectTreeImage.TableSpace: return "TableSpace";
                case ObjectTreeImage.TablePartition: return "TablePartition";
                default: return "Folder";
            }
        }
        public static FormPageType StringToFormPageType(string SType)
        {
            switch (SType)
            {
                case "SingleTable": return FormPageType.SingleTable;
                case "DoubleTable": return FormPageType.DoubleTable;
                case "BigTable": return FormPageType.BigTable;
                case "Text": return FormPageType.Text;
                case "Script": return FormPageType.Script;
                case "Action": return FormPageType.Action;
                default: return FormPageType.SingleTable;
            }
        }
        public static string FormPageTypeToString(FormPageType CType)
        {
            switch (CType)
            {
                case FormPageType.SingleTable: return "SingleTable";
                case FormPageType.DoubleTable: return "DoubleTable";
                case FormPageType.BigTable: return "BigTable";
                case FormPageType.Text: return "Text";
                case FormPageType.Script: return "Script";
                case FormPageType.Action: return "Action";
                default: return "SingleTable";
            }
        }
        public static string SecsToString(int i) 
        {
            int hour;
            int minute;
            int second;
            hour = i / 3600;
            minute = (i % 3660 / 60);
            second = i % 60;
            return ("0" + hour)[^2..] + ":" + ("0" + minute)[^2..] + ":" + ("0" + second)[^2..];
        }
        public static IBrush FromHex(string hex)
        {
            if (string.IsNullOrWhiteSpace(hex))
                return Brushes.Transparent;

            try
            {
                var color = Color.Parse(hex); // понимает #RGB, #RRGGBB, #AARRGGBB
                return new SolidColorBrush(color);
            }
            catch
            {
                return Brushes.Transparent;
            }
        }
    }
}
