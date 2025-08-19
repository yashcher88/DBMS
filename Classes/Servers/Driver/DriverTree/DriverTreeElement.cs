using DBMS.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

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
        public void LoadFromJson(JsonObject J)
        {

        }
        public JsonObject SaveToJson()
        {
            JsonObject J = new JsonObject();

            return J;
        }
    }
}
