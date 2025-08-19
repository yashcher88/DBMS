using Avalonia.Controls;
using DBMS.Enums;
using DBMS.Functions;
using System.Collections.Generic;
using System.Text.Json.Nodes;

namespace DBMS.Classes
{
    public class LanguageWindow : LanguageControl
    {
        /*
         * Объект окна, содержит в себе все элементы, которые есть в окне
         */
        public Dictionary<string,LanguageControl> LanguageControls = new Dictionary<string,LanguageControl>();
        public void ReadFromWindow(Window W, bool isRewrite) {
            ControlType = UserControlType.Window;
            ControlProperty = UserControlProperty.Title;
            SetTitle(W.Title, isRewrite);

            var A = Functions.Form.GetControls(W);
            for (var i = 0; i < A.Count; i++) 
            {
                if (!string.IsNullOrEmpty(A[i].Name))
                {
                    LanguageControl LC;
                    string CName = A[i].GetType().Name + "_" + A[i].Name;
                    if (LanguageControls.ContainsKey(CName))
                    {
                        LC = LanguageControls[CName];
                    }
                    else
                    {
                        LC = new LanguageControl();
                        LanguageControls.Add(CName, LC);
                    }
                    LC.ReadFromControl(A[i],isRewrite);
                }
            }
        }
        public void LoadWindowFromJson(JsonObject J)
        {
            LoadFromJson(J);
            if (J["LanguageControls"] != null) {
                foreach (var node in J["LanguageControls"].AsObject()) 
                { 
                    LanguageControl LControl = new LanguageControl();
                    LControl.LoadFromJson(node.Value.AsObject());
                    LanguageControls.Add(node.Key,LControl);
                }
            }
        }
        public JsonObject SaveWindowToJson()
        {
            JsonObject J = SaveToJson();
            J["LanguageControls"] = new JsonObject();
            foreach (var node in LanguageControls)
            {
                J["LanguageControls"][node.Key] = node.Value.SaveToJson();
            }
            return J;
        }
        public void WriteToWindow(Window W) {
            if (Title != null)
            {
                W.Title = Title;
                var A = Functions.Form.GetControls(W);
                for (var i = 0; i < A.Count; i++)
                {
                    if (!string.IsNullOrEmpty(A[i].Name))
                    {
                        string CName = A[i].GetType().Name + "_" + A[i].Name;
                        if (LanguageControls.ContainsKey(CName))
                        {
                            LanguageControls[CName].WriteToControl(A[i]);
                        }
                    }
                }
            }
        }
        public LanguageWindow CloneWindow() 
        { 
            LanguageWindow window = new LanguageWindow();

            window.ControlType = ControlType;
            window.ControlProperty = ControlProperty;
            window.isDelete = isDelete;
            window.Text = Text;
            window.Header = Header;
            window.Content = Content;
            window.ToolTip = ToolTip;
            window.Title = Title;
            window.WaterMark = WaterMark;

            window.LanguageControls = new Dictionary<string, LanguageControl>();
            foreach (var node in LanguageControls) 
            {
                window.LanguageControls.Add(node.Key, node.Value.CloneControl());
            }
            return window;
        }
    }
}
