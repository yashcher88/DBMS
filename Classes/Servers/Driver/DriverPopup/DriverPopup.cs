using Avalonia.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace DBMS.Classes
{
    public class DriverPopup
    {
        public string Name;
        public List<DriverPopupElement> Child = new List<DriverPopupElement>();

        public void LoadFromJson(JsonObject J)
        {
            Name = J["Name"].ToString();
            Child.Clear();
            for (var i = 0; i < J["Child"].AsArray().Count; i++) 
            {
                var C = new DriverPopupElement();
                C.LoadFromJson(J["Child"].AsArray()[i].AsObject());
                Child.Add(C);
            }
        }
        public JsonObject SaveToJson()
        {
            JsonObject J = new JsonObject();
            J["Name"] = Name;
            J["Child"] = new JsonArray();
            foreach (var item in Child) 
            {
                J["Child"].AsArray().Add(item.SaveToJson());
            }
            return J;
        }
    }
}
