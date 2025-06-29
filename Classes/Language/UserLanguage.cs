using DBMS.Classes.Language;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace DBMS.Classes
{
    /*Языковой объект в Controls должны лежать формы, в Objects - дополнительные объекты для перевода*/
    public class UserLanguage
    {
        Dictionary<string, UserControlLanguage> Controls = new Dictionary<string, UserControlLanguage>();
        Dictionary<string, string> Objects = new Dictionary<string, string>();
        public void LoadFromJson(JsonObject J) {
            if (J["Controls"] != null)
            {
                foreach (var node in J["Controls"].AsObject())
                {
                    var CLanguage = new UserControlLanguage();
                    CLanguage.Code = node.Key;
                    CLanguage.LoadFromJson(node.Value.AsObject());
                    Controls.Add(node.Key, CLanguage);
                }
                Objects.Clear();
                foreach (var node in J["Objects"].AsObject())
                {
                    Objects.Add(node.Key, node.Value.ToString());
                }
            }
        }
        public JsonNode SaveToJson() { 
            JsonNode J = new JsonObject();
            J["Controls"] = new JsonObject();
            foreach (var node in Controls)
            {
                J["Controls"][node.Key] = node.Value.SaveToJson();
            }
            J["Objects"] = new JsonObject();
            foreach (var node in Objects)
            {
                J["Objects"][node.Key] = node.Value;
            }
            return J;
        }
    }
}
