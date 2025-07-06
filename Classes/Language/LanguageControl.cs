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
            ControlType = CConvert.StringToUserControlType(J["ControlType"]?.ToString());
            ControlProperty = CConvert.ArrayToUserControlProperty(J["ControlProperty"].AsArray());
        }
        public JsonObject SaveToJson()
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
            return J;
        }
        public void LoadFromControl(Control C, bool isRewrite)
        {
            switch (C.GetType().Name)
            {
                case "Button":
                    FillAsButton(C, isRewrite);
                    break;
                case "MenuItem":
                    FillAsMenuItem(C, isRewrite);
                    break;
                case "TabItem":
                    FillAsTabItem(C, isRewrite);
                    break;
                case "TextBlock":
                    FillAsTextBlock(C, isRewrite);
                    break;
                case "TextBox":
                    FillAsTextBox(C, isRewrite);
                    break;
            }
        }

        private void FillAsButton(Control C, bool isRewrite)
        {
            ControlType = UserControlType.Button;
            ControlProperty = UserControlProperty.Content | UserControlProperty.ToolTip;
            SetContent((C as Button).Content.ToString(), isRewrite);
            SetToolTip(Avalonia.Controls.ToolTip.GetTip(C)?.ToString(), isRewrite);
        }
        private void FillAsMenuItem(Control C, bool isRewrite)
        {
            ControlType = UserControlType.MenuItem;
            ControlProperty = UserControlProperty.Header | UserControlProperty.ToolTip;
            SetHeader((C as MenuItem).Header?.ToString(), isRewrite);
            SetContent(Avalonia.Controls.ToolTip.GetTip(C)?.ToString(), isRewrite);
        }
        private void FillAsTabItem(Control C, bool isRewrite)
        {
            ControlType = UserControlType.TabItem;
            ControlProperty = UserControlProperty.Header | UserControlProperty.ToolTip;
            SetHeader((C as TabItem).Header?.ToString(), isRewrite);
            SetContent(Avalonia.Controls.ToolTip.GetTip(C)?.ToString(), isRewrite);
        }
        private void FillAsTextBlock(Control C, bool isRewrite)
        {
            ControlType = UserControlType.TextBlock;
            ControlProperty = UserControlProperty.Text;
            SetText((C as TextBox).Text, isRewrite);
        }
        private void FillAsTextBox(Control C, bool isRewrite)
        {
            ControlType = UserControlType.TextBox;
            ControlProperty = UserControlProperty.Text | UserControlProperty.WaterMark;
            SetText((C as TextBox).Text, isRewrite);
            SetWaterMark((C as TextBox).Watermark, isRewrite);
        }
        public void SetValue(string value, ref string Elem, bool isRewrite, UserControlProperty Property) {
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
