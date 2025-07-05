using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.VisualTree;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DBMS.Classes;

namespace DBMS.Functions
{
    static class Form
    {
        private static List<Control> GetMenuControls(MenuItem W, ref List<Control> M)
        {
            if (W?.Items != null)
            {
                for (int i = 0; i < W.Items.Count; i++)
                {
                    if (W.Items[i] != null)
                    {
                        if (!string.IsNullOrEmpty((W.Items[i] as Control).Name))
                        {
                            M.Add(W.Items[i] as Control);
                            GetMenuControls(W.Items[i] as MenuItem, ref M);
                        }
                    }
                }
            }
            return M;
        }
        public static List<Control> GetControls(Window W) {
            List<Control> M = new List<Control>();
            var A = W.GetVisualDescendants().OfType<Control>();
            foreach (var m in A)
            {
                if (!string.IsNullOrEmpty(m.Name))
                {
                    M.Add(m);
                }
                if (m is MenuItem)
                {
                    GetMenuControls(m as MenuItem, ref M);
                }
            }
            return M;
        }
        public static void ToggleButton(object sender, string Class1, string Class2) {
            if ((sender as Button).Classes.Contains(Class1))
            {
                (sender as Button).Classes.Remove(Class1);
                (sender as Button).Classes.Add(Class2);
            }
            else
            {
                (sender as Button).Classes.Remove(Class2);
                (sender as Button).Classes.Add(Class1);
            }
        }
        async static public Task<ButtonResult> ShowErrorModalOk(BaseForm BlockWindow, string message)
        {
            var messageBox = MessageBoxManager.GetMessageBoxStandard(
                        Assembly.GetEntryAssembly()?.GetName().Name ?? "Unknown",
                        message,
                        ButtonEnum.Ok,
                        MsBox.Avalonia.Enums.Icon.Info
                    );
            var result = await messageBox.ShowWindowDialogAsync(BlockWindow);
            return result;
        }
    }
}
