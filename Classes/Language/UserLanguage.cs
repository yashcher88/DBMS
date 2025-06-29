using Avalonia.Controls;
using DBMS.Classes.Language;
using DBMS.Functions;
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
        public Dictionary<string, UserControlLanguage> Controls = new Dictionary<string, UserControlLanguage>();
        public Dictionary<string, string> Objects = new Dictionary<string, string>();
        public bool IsDefault = false;
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
        public void LoadFromWindow(Window W) {
            UserControlLanguage WinControl;
            var A = Form.GetControls(W);
            var WinName = W.GetType().Name;
            if (!Controls.ContainsKey(WinName))
            {
                WinControl = new UserControlLanguage();
                WinControl.UserControl = new UserControlWindow();
                WinControl.UserControl.SetTitle(W.Title);
            }
            else 
            { 
                WinControl = Controls[WinName];
            }
            foreach (var B in A) 
            { 
                
            }

            /*if (!Objects.ContainsKey(WName))
            {
                WObj = new InterfaceLanguageObject();
                WObj.ObjectType = LanguageTextType.Title;
                WObj.Objects = new Dictionary<string, InterfaceLanguageObject>();
                Objects.Add(W.GetType().Name, WObj);
            }
            else
            {
                WObj = Objects[WName];
            }
            if (W.Title != null) WObj.SetDefaultTitle(W.Title);

            foreach (var B in A)
            {
                if (!string.IsNullOrEmpty(B.Name) && B.Name.StartsWith("E_"))
                {
                    InterfaceLanguageObject WSObj;
                    var SName = B.GetType().Name + "_" + B.Name;
                    if (!WObj.Objects.ContainsKey(SName))
                    {
                        WSObj = new InterfaceLanguageObject();
                        WObj.Objects.Add(SName, WSObj);
                    }
                    else
                    {
                        WSObj = WObj.Objects[SName];
                    }
                    WSObj.ObjectType = GetTypeOfObject(B.GetType().Name);
                    SetDefaultValues(WSObj, B);
                }
            }
            */
        }
    }
}
