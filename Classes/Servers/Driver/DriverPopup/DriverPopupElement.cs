using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace DBMS.Classes
{
    public class DriverPopupElement
    {
        public string Name;
        public DriverScriptLink Caption;
        public List<DriverPopupEvent> Events = new List<DriverPopupEvent>();
        public List<DriverPopupElement> Child = new List<DriverPopupElement>();
        public void LoadFromJson(JsonObject J)
        {
            Name = J["Name"].ToString();
            Caption = new DriverScriptLink();
            Caption.LoadFromJson(J["Caption"].AsObject());
            Events.Clear();
            for (var i = 0; i < J["Events"].AsArray().Count(); i++)
            {
                var D1 = new DriverPopupEvent();
                D1.LoadFromJson(J["Events"].AsArray()[i].AsObject());
                Events.Add(D1);
            }
            Child.Clear();
            for (var i = 0; i < J["Child"].AsArray().Count(); i++)
            {
                var D2 = new DriverPopupElement();
                D2.LoadFromJson(J["Child"].AsArray()[i].AsObject());
                Child.Add(D2);
            }
        }
        public JsonObject SaveToJson()
        {
            JsonObject J = new JsonObject();
            J["Name"] = Name;
            J["Caption"] = Caption.SaveToJson();
            J["Events"] = new JsonArray();
            for (var i = 0; i < Events.Count(); i++)
            {
                J["Events"].AsArray().Add(Events[i].SaveToJson());
            }
            J["Child"] = new JsonArray();
            for (var i = 0; i < Child.Count(); i++)
            {
                J["Child"].AsArray().Add(Child[i].SaveToJson());
            }
            return J;
        }
    }
}
