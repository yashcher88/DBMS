using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Enums;

namespace DBMS.Classes
{
    internal class DriverTreeElement
    {
        public string Name = "";
        public string Hint = "";
        public string ObjectId = "";
        public string PopupRuleMap = "";
        public ObjectTreeImage Image;
        public ObjectTreeNodeType NodeType;
        public DriverTreeElement Parent;
        public DriverTreeTemplate Template;
        public List<DriverTreeElement> Child;

        public DriverTreeElement(DriverTreeElement _parent) 
        { 
            Parent = _parent;
        }
    }
}
