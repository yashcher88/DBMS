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
    }
}
