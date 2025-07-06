using Avalonia.Controls;
using DBMS.Classes.Language.Old;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Classes
{
    public class LanguageObject
    {
        public Dictionary<string, LanguageElement> Languages = new Dictionary<string, LanguageElement>();
        public LanguageObject() { 
            LanguageElement L = new LanguageElement();
            Languages.Add("Русский", L);
        }
        public void FillLanguageByWindow(Window W) { 
            
        }
    }
}
