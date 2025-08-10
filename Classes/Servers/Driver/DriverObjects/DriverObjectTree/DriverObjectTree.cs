using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using DBMS.Enums;

namespace DBMS.Classes
{
    public class DriverObjectTree
    {
        public string Name = "";
        public string Caption = "";
        public string Hint = "";
        public string Image = "Folder";
        public string ObjId = "";
        public ObjectTreeNodeType NodeType = ObjectTreeNodeType.Unknown;
        public bool Expanded = false;
        public bool Wait = true;
        public int MinVersion = 0;
        public int MaxVersion = 2147483647;
        public bool Filtered = false;
        public JsonNode Json = null;
        public string Node = "";
        public ScriptLink Tree = null;
        public ScriptLink One = null;
        public string RuleMap = "";
        public string Popup = "";
        public string PopupGroup = "";
        //public TreeNode TNode = null;
        public Connection C = null;
    }
}
