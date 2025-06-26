using DBMS.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Classes
{
    public class UserControl
    {
        public int Id;
        public string Code;
        public ControlType ControlType;
        public List<UserControl> Controls;
        public UserControl ParentControl = null;
        public List<ControlLanguage> controlLanguages = new List<ControlLanguage>();
    }
}
