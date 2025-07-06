using Avalonia.Controls;
using DBMS.Enums;
using DBMS.Functions;
using System.Collections.Generic;

namespace DBMS.Classes
{
    public class LanguageWindow : LanguageControl
    {
        /*
         * Объект окна, содержит в себе все элементы, которые есть в окне
         */
        public Dictionary<string,LanguageControl> LanguageControls = new Dictionary<string,LanguageControl>();
        public void FillAsWindow(Control C, bool isRewrite)
        {
            ControlType = UserControlType.Window;
            ControlProperty = UserControlProperty.Title;
            SetTitle((C as Window).Title, isRewrite);
        }
        public void LoadFromWindow(Window W, bool isRewrite) {
            var A = Form.GetControls(W);
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
                    LC.LoadFromControl(A[i],isRewrite);
                }
            }
        }
    }
}
