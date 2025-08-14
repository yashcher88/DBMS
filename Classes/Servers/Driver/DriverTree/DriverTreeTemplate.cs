
using DBMS.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Classes
{
    public class DriverTreeTemplate
    {
        public string StaticObjId = "";
        public string StaticPopupRuleMap = "";
        public string PopupGroup;

        public bool Expanded = false;
        public bool Wait = true;
        public bool Filtered = false;

        public int MinVersion = 0;
        public int MaxVersion = 2147483647;

        public DriverPopup Popup;

        public DriverScriptLink StaticName;
        public DriverScriptLink StaticCaption;
        public DriverScriptLink StaticHint;

        public DriverScriptLink Tree;
        public DriverScriptLink One;

        public ObjectTreeImage Image;
        public ObjectTreeNodeType NodeType;

        public List<string> Childs = new List<string>();
    }
}
