using Avalonia.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Controls.Primitives;
using Avalonia.VisualTree;

namespace DBMS.Functions
{
    static class Form
    {
        public static List<Control> GetControls(Window W) { 
            List<Control> M = new List<Control>();
            var A = W.GetVisualDescendants().OfType<Control>();
            foreach (var m in A) { 
                M.Add(m);
                if (m is MenuItem) {
                    //m.GetVisualDescendants().
                }
            }
            return M;
        }
    }
}
