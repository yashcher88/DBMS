using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Enums;

namespace DBMS.Classes.Style.UserStyle
{
    public class UserStyle
    {
        public int Id;
        public string Code;
        public StyleType StyleType;
        public List<UserStyleLanguage> StyleLanguage = new List<UserStyleLanguage>();
    }
}
