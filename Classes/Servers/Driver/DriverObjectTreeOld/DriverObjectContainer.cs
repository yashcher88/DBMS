using Avalonia.Markup.Xaml.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace DBMS.Classes
{
    public class DriverObjectContainer
    {
        public bool isScript;
        public DriverScriptLink Tree = null;
        public DriverScriptLink One = null;
        public DriverObjectNode ObjectNode;
        public void LoadFromJson(JsonObject J) 
        {
            if (J["Tree"] != null)
            {
                Tree = new DriverScriptLink();
                Tree.LoadFromJson(J["Tree"].AsObject());
            }
            if (J["One"] != null)
            {
                One = new DriverScriptLink();
                One.LoadFromJson(J["One"].AsObject());
            }
            ObjectNode = new DriverObjectNode();
            ObjectNode.LoadFromJson(J["ObjectNode"].AsObject());
        }
        public JsonObject SaveToJson() 
        {
            JsonObject J = new JsonObject();
            if (Tree != null) J["Tree"] = Tree.SaveToJson();
            if (One != null) J["One"] = One.SaveToJson();
            J["ObjectNode"] = ObjectNode.SaveToJson();
            return J;
        }
    }
}
