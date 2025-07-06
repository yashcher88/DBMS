using Avalonia.Controls;
using DBMS.Classes;
using DBMS.Classes.Language.Old.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Functions
{
    static class CConvert
    {
        public static UserControl StringToControlType(string CType) {
            switch (CType) {
                case "Window": return new UserControlWindow(); 
                case "MenuItem": return new UserControlMenuItem();
                case "TabItem": return new UserControlTabItem(); 
                case "Button": return new UserControlButton();
                case "TextBlock": return new UserControlTextBlock();
                case "TextBox": return new UserControlTextBox();
                default: return new UserControl();
            }
        }
        public static string ControlTypeToString(UserControl CType)
        {
            switch (CType.GetType().Name)
            {
                case "UserControlWindow": return "Window";
                case "UserControlMenuItem": return "MenuItem";
                case "UserControlTabItem": return "TabItem";
                case "UserControlButton": return "Button";
                case "UserControlTextBlock": return "TextBlock";
                case "UserControlTextBox": return "TextBox";
                default: return "";
            }
        }
        public static UserControl GetUserControlFromControl(Control C) { 
            UserControl u;
            switch (C.GetType().Name) {
                default: u = new UserControl();
            }
            return u;
        }
    }
}
