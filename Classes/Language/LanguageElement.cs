using DBMS.Classes.Language.Old;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Classes
{
    public class LanguageElement
    {
        public Dictionary<string, LanguageWindow> Windows = new Dictionary<string, LanguageWindow>();
        public Dictionary<string, string> List = new Dictionary<string, string>();

    }
}
