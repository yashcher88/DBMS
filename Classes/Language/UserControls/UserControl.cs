using Avalonia.Controls;
using DBMS.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
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
        public string ToolTip;
        public string Title;
        public string WaterMark;
        public void LoadFromJson(JsonObject J)
        {
            SetText(J["Text"]?.ToString());
            SetHeader(J["Header"]?.ToString());
            SetContent(J["Content"]?.ToString());
            SetToolTip(J["ToolTip"]?.ToString());
            SetText(J["Title"]?.ToString());
            SetWaterMark(J["WaterMark"]?.ToString());
        }

        public JsonObject SaveToJson(JsonObject J)
        {
            if (Text != null) { J["Text"] = Text;}
            if (Header != null) { J["Header"] = Text; }
            if (Content != null) { J["Content"] = Text; }
            if (ToolTip != null) { J["ToolTip"] = Text; }
            if (Title != null) { J["Title"] = Text; }
            if (WaterMark != null) { J["WaterMark"] = Text; }
            return J;
        }
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
                ToolTip = value;
            }
        }
        public void SetTitle(string value)
        {
            if (ControlProperty.HasFlag(UserControlProperty.Title))
            {
                Title = value;
            }
        }
        public void SetWaterMark(string value)
        {
            if (ControlProperty.HasFlag(UserControlProperty.WaterMark))
            {
                WaterMark = value;
            }
        }

    }
}
