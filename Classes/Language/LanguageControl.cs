using Avalonia.Controls;
using DBMS.Enums;
using DBMS.Functions;
using System.Text.Json.Nodes;

namespace DBMS.Classes
{
    public class LanguageControl
    {
        /*
         * Объект - элемент на форме, также форма является наследником этого объекта
         */
        public UserControlType ControlType;
        public UserControlProperty ControlProperty = 0;
        public bool isDelete = false;
        public string Text;
        public string Header;
        public string Content;
        public string ToolTip;
        public string Title;
        public string WaterMark;
        public void LoadControlFromJson(JsonObject J)
        {
            SetText(J["Text"]?.ToString());
            SetHeader(J["Header"]?.ToString());
            SetContent(J["Content"]?.ToString());
            SetToolTip(J["ToolTip"]?.ToString());
            SetTitle(J["Title"]?.ToString());
            SetWaterMark(J["WaterMark"]?.ToString());
            ControlType = CConvert.StringToUserControlType(J["ControlType"]?.ToString());
            ControlProperty = CConvert.ArrayToUserControlProperty(J["ControlProperty"].AsArray());
            isDelete = ((bool?)J["isDelete"]) ?? false;
        }
        public JsonObject SaveControlToJson()
        {
            JsonObject J = new JsonObject();
            if (Text != null) { J["Text"] = Text; }
            if (Header != null) { J["Header"] = Text; }
            if (Content != null) { J["Content"] = Text; }
            if (ToolTip != null) { J["ToolTip"] = Text; }
            if (Title != null) { J["Title"] = Text; }
            if (WaterMark != null) { J["WaterMark"] = Text; }
            J["ControlType"] = CConvert.UserControlTypeToString(ControlType);
            J["ControlProperty"] = CConvert.UserControlPropertyToArray(ControlProperty);
            J["isDelete"] = isDelete;
            return J;
        }
        public void ReadFromControl(Control C, bool isRewrite)
        {
            switch (C.GetType().Name)
            {
                case "Button":
                    ReadFromButton(C as Button, isRewrite);
                    break;
                case "MenuItem":
                    ReadFromMenuItem(C as MenuItem, isRewrite);
                    break;
                case "TabItem":
                    ReadFromTabItem(C as TabItem, isRewrite);
                    break;
                case "TextBlock":
                    ReadFromTextBlock(C as TextBlock, isRewrite);
                    break;
                case "TextBox":
                    ReadFromTextBox(C as TextBox, isRewrite);
                    break;
            }
        }
        public void WriteToControl(Control C) 
        {
            switch (ControlType) 
            {
                case UserControlType.MenuItem:
                    WriteToMenuItem(C as MenuItem);
                    break;
                case UserControlType.Button:
                    WriteToButton(C as Button);
                    break;
                case UserControlType.TabItem:
                    WriteToTabItem(C as TabItem);
                    break;
                case UserControlType.TextBlock:
                    WriteToTextBlock(C as TextBlock);
                    break;
                case UserControlType.TextBox:
                    WriteToTextBox(C as TextBox);
                    break;
            }
        }

        private void ReadFromButton(Button C, bool isRewrite)
        {
            ControlType = UserControlType.Button;
            ControlProperty = UserControlProperty.Content | UserControlProperty.ToolTip;
            SetContent(C.Content.ToString(), isRewrite);
            SetToolTip(Avalonia.Controls.ToolTip.GetTip(C)?.ToString(), isRewrite);
        }
        private void ReadFromMenuItem(MenuItem C, bool isRewrite)
        {
            ControlType = UserControlType.MenuItem;
            ControlProperty = UserControlProperty.Header | UserControlProperty.ToolTip;
            SetHeader(C.Header?.ToString(), isRewrite);
            SetToolTip(Avalonia.Controls.ToolTip.GetTip(C)?.ToString(), isRewrite);
        }
        private void ReadFromTabItem(TabItem C, bool isRewrite)
        {
            ControlType = UserControlType.TabItem;
            ControlProperty = UserControlProperty.Header | UserControlProperty.ToolTip;
            SetHeader(C.Header?.ToString(), isRewrite);
            SetContent(Avalonia.Controls.ToolTip.GetTip(C)?.ToString(), isRewrite);
        }
        private void ReadFromTextBlock(TextBlock C, bool isRewrite)
        {
            ControlType = UserControlType.TextBlock;
            ControlProperty = UserControlProperty.Text;
            SetText(C.Text, isRewrite);
        }
        private void ReadFromTextBox(TextBox C, bool isRewrite)
        {
            ControlType = UserControlType.TextBox;
            ControlProperty = UserControlProperty.Text | UserControlProperty.WaterMark;
            SetText(C.Text, isRewrite);
            SetWaterMark(C.Watermark, isRewrite);
        }

        private void WriteToButton(Button C)
        {
            if (Content != null)
            {
                C.Content = Content;
            }
            if (ToolTip != null) 
            {
                Avalonia.Controls.ToolTip.SetTip(C, ToolTip);
            }
        }
        private void WriteToMenuItem(MenuItem C)
        {
            if (Header != null)
            {
                C.Header = Header;
            }
            if (ToolTip != null)
            {
                Avalonia.Controls.ToolTip.SetTip(C, ToolTip);
            }
        }
        private void WriteToTabItem(TabItem C)
        {
            if (Header != null)
            {
                C.Header = Header;
            }
            if (Header != null)
            {
                Avalonia.Controls.ToolTip.SetTip(C, ToolTip);
            }
        }
        private void WriteToTextBlock(TextBlock C)
        {
            if (Text != null) 
            { 
                C.Text = Text;
            }
        }
        private void WriteToTextBox(TextBox C)
        {
            if (Text != null)
            {
                C.Text = Text;
            }
            if (WaterMark != null)
            {
                C.Watermark = WaterMark;
            }
        }
        private void SetValue(string value, ref string Elem, bool isRewrite, UserControlProperty Property) {
            if (ControlProperty.HasFlag(Property) && (isRewrite || Elem == null)) {
                Elem = value;
            }
        }
        protected void SetText(string value, bool isRewrite = true)
        {
            SetValue(value, ref Text, isRewrite, UserControlProperty.Text);
        }
        protected void SetHeader(string value, bool isRewrite = true)
        {
            SetValue(value, ref Header, isRewrite, UserControlProperty.Header);
        }
        protected void SetContent(string value, bool isRewrite = true)
        {
            SetValue(value, ref Content, isRewrite, UserControlProperty.Content);
        }
        protected void SetToolTip(string value, bool isRewrite = true)
        {
            SetValue(value, ref ToolTip, isRewrite, UserControlProperty.ToolTip);
        }
        protected void SetTitle(string value, bool isRewrite = true)
        {
            SetValue(value, ref Title, isRewrite, UserControlProperty.Title);
        }
        protected void SetWaterMark(string value, bool isRewrite = true)
        {
            SetValue(value, ref WaterMark, isRewrite, UserControlProperty.WaterMark);
        }
    }
}
