using Avalonia.Controls;
using DBMS.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Classes
{
    public class UserControl
    {
        public UserControlType ControlType;
        public UserControlProperty ControlProperty = 0;
        public string Text;
        public string Header;
        public string Content;
        public string Tooltip;
        public string Title;
        public void SetText(string value)
        {
            if (ControlProperty.HasFlag(UserControlProperty.Text))
            {
                Text = value;
            }
        }
        public void SetHeader(string value)
        {
            if (ControlProperty.HasFlag(UserControlProperty.Header))
            {
                Header = value;
            }
        }
        public void SetContent(string value)
        {
            if (ControlProperty.HasFlag(UserControlProperty.Content))
            {
                Content = value;
            }
        }
        public void SetToolTip(string value)
        {
            if (ControlProperty.HasFlag(UserControlProperty.ToolTip))
            {
                Tooltip = value;
            }
        }
        public void SetTitle(string value)
        {
            if (ControlProperty.HasFlag(UserControlProperty.Title))
            {
                Title = value;
            }
        }

    }
}
