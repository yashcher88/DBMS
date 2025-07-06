using DBMS.Classes.Language.Old.UserControls;
using DBMS.Enums;
using DBMS.Functions;
using HarfBuzzSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DBMS.Classes.Language.Old
{
    /*Языковой пакет*/
    public class UserControlLanguage
    {
        public string Code;
        public UserControl UserControl;
        public Dictionary<string, UserControlLanguage> Controls = new Dictionary<string, UserControlLanguage>();
        public void LoadFromJson(JsonObject J)
        {
            UserControl = CConvert.StringToControlType(J["ControlType"].ToString());
            UserControl.LoadFromJson(J);
            foreach (var node in J["Controls"].AsObject())
            {
                var CLanguage = new UserControlLanguage();
                CLanguage.Code = node.Key;
                CLanguage.LoadFromJson(node.Value.AsObject());
                Controls.Add(node.Key, CLanguage);
            }
        }
        public JsonNode SaveToJson()
        {
            JsonObject J = new JsonObject();
            J = UserControl.SaveToJson(J);
            J["ControlType"] = CConvert.ControlTypeToString(UserControl);
            if (Controls.Count > 0)
            {
                J["Controls"] = new JsonObject();
                foreach (var node in Controls)
                {
                    J["Controls"][node.Key] = node.Value.SaveToJson();
                }
            }
            return J;
        }
    }
}
