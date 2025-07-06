using Avalonia.Controls;
using Avalonia.VisualTree;
using DBMS.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace DBMS.Classes
{
    public class LanguageControl
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
            if (Text != null) { J["Text"] = Text; }
            if (Header != null) { J["Header"] = Text; }
            if (Content != null) { J["Content"] = Text; }
            if (ToolTip != null) { J["ToolTip"] = Text; }
            if (Title != null) { J["Title"] = Text; }
            if (WaterMark != null) { J["WaterMark"] = Text; }
            return J;
        }
        public void LoadFromControl(Control C)
        {
            switch (C.GetType().Name)
            {
                case "Button":
                    FillAsButton(C);
                    break;
                case "MenuItem":
                    FillAsMenuItem(C);
                    break;
                case "TabItem":
                    FillAsTabItem(C);
                    break;
                case "TextBlock":
                    FillAsTextBlock(C);
                    break;
                case "TextBox":
                    FillAsTextBox(C);
                    break;
            }
        }

        private void FillAsButton(Control C)
        {
            ControlType = UserControlType.Button;
            ControlProperty = UserControlProperty.Content | UserControlProperty.ToolTip;
            SetContent((C as Button).Content.ToString());
            SetContent(Avalonia.Controls.ToolTip.GetTip(C)?.ToString());
        }
        private void FillAsMenuItem(Control C)
        {
            ControlType = UserControlType.MenuItem;
            ControlProperty = UserControlProperty.Header | UserControlProperty.ToolTip;
            SetHeader((C as MenuItem).Header?.ToString());
            SetContent(Avalonia.Controls.ToolTip.GetTip(C)?.ToString());
        }
        private void FillAsTabItem(Control C)
        {
            ControlType = UserControlType.TabItem;
            ControlProperty = UserControlProperty.Header | UserControlProperty.ToolTip;
            SetHeader((C as TabItem).Header?.ToString());
            SetContent(Avalonia.Controls.ToolTip.GetTip(C)?.ToString());
        }
        private void FillAsTextBlock(Control C)
        {
            ControlType = UserControlType.TextBlock;
            ControlProperty = UserControlProperty.Text;
            SetText((C as TextBox).Text);
        }
        private void FillAsTextBox(Control C)
        {
            ControlType = UserControlType.TextBox;
            ControlProperty = UserControlProperty.Text | UserControlProperty.WaterMark;
            SetText((C as TextBox).Text);
            SetWaterMark((C as TextBox).Watermark);
        }
        protected void FillAsWindow(Control C)
        {
            ControlType = UserControlType.Window;
            ControlProperty = UserControlProperty.Title;
            SetTitle((C as Window).Title);
        }
        protected void SetText(string value)
        {
            if (ControlProperty.HasFlag(UserControlProperty.Text))
            {
                Text = value;
            }
        }
        protected void SetHeader(string value)
        {
            if (ControlProperty.HasFlag(UserControlProperty.Header))
            {
                Header = value;
            }
        }
        protected void SetContent(string value)
        {
            if (ControlProperty.HasFlag(UserControlProperty.Content))
            {
                Content = value;
            }
        }
        protected void SetToolTip(string value)
        {
            if (ControlProperty.HasFlag(UserControlProperty.ToolTip))
            {
                ToolTip = value;
            }
        }
        protected void SetTitle(string value)
        {
            if (ControlProperty.HasFlag(UserControlProperty.Title))
            {
                Title = value;
            }
        }
        protected void SetWaterMark(string value)
        {
            if (ControlProperty.HasFlag(UserControlProperty.WaterMark))
            {
                WaterMark = value;
            }
        }
    }
}
