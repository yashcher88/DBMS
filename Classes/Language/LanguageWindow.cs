using Avalonia.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Classes
{
    public class LanguageWindow : LanguageControl
    {
        public Dictionary<string,LanguageControl> LanguageControls = new Dictionary<string,LanguageControl>();
        public LanguageWindow(Window W) {
            FillAsWindow(W);
        }
    }
}
