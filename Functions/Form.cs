using Avalonia.Controls;
using Avalonia.VisualTree;
using DBMS.Classes;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DBMS.Functions
{
    static class Form
    {
        private static List<Control> GetMenuControls(MenuItem MI, ref List<Control> M)
        {
            if (MI?.Items != null)
            {
                for (int i = 0; i < MI.Items.Count; i++)
                {
                    if (MI.Items[i] != null)
                    {
                        if (!string.IsNullOrEmpty((MI.Items[i] as Control).Name))
                        {
                            M.Add(MI.Items[i] as Control);
                            GetMenuControls(MI.Items[i] as MenuItem, ref M);
                        }
                    }
                }
            }
            return M;
        }
        public static List<Control> GetControls(Window W) {
            List<Control> M = new List<Control>{W};
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
        public static List<Control> GetControlsFormUserControl(BaseUserControl B) 
        {
            List<Control> M = new List<Control> { B };
            var A = B.GetVisualDescendants().OfType<Control>();
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
        async static public Task<ButtonResult> ShowErrorModalOk(BaseWindow BlockWindow, string message)
        {
            /*В вызываемой функции необходимо этот метод вызывать с параметром await и функцию помечать как async */
            var messageBox = MessageBoxManager.GetMessageBoxStandard(
                        Assembly.GetEntryAssembly()?.GetName().Name ?? "Unknown",
                        message,
                        ButtonEnum.Ok,
                        Icon.Error
                    );
            return await messageBox.ShowWindowDialogAsync(BlockWindow);
        }
    }
}
