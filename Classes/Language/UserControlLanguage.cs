using DBMS.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Classes.Language
{
    public class UserControlLanguage
    {
        public string Code;
        public UserControl UserControl;
        Dictionary<string, UserControlLanguage> Controls = new Dictionary<string, UserControlLanguage>();
    }
}
