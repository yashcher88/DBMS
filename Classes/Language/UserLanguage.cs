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
    public class UserLanguage
    {
        Dictionary<string, UserControlLanguage> Controls = new Dictionary<string, UserControlLanguage>();
        public void LoadFromJson(JsonObject J) {
            foreach (var node in J) {
                var CLanguage = new UserControlLanguage();
                CLanguage.Code = node.Key;
                CLanguage.LoadFromJson(node.Value.AsObject());
                Controls.Add(node.Key, CLanguage);
            }
        }
        public JsonNode SaveToJson() { 
            JsonNode J = new JsonObject();
            foreach (var node in Controls)
            {
                J[node.Key] = node.Value.SaveToJson();
            }
            return J;
        }
    }
}
