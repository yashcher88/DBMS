using Avalonia.Controls;
using DBMS.Functions;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace DBMS.Classes.Language.Old
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
        public UserControlLanguage GetUserControlLanguage(Dictionary<string,UserControlLanguage> D,Control C)
        {
            UserControlLanguage UControl;
            var ControlName = C.GetType().Name + "_" + C.Name;
            if (!Controls.ContainsKey(ControlName))
            {
                UControl = new UserControlLanguage();
                

                UControl.UserControl = new UserControlWindow();
                
                UControl.UserControl.SetTitle(C.Title);

                Controls.Add(ControlName, UControl);
            }
            else
            {
                UControl = Controls[ControlName];
            }
            return UControl;
        }
        public UserControlLanguage GetWindowControlLanguage(Window W)
        {
            UserControlLanguage WinControl;
            var WinName = W.GetType().Name;
            if (!Controls.ContainsKey(WinName))
            {
                WinControl = new UserControlLanguage();
                WinControl.UserControl = new UserControlWindow();
                WinControl.UserControl.SetTitle(W.Title);
                Controls.Add(WinName, WinControl);
            }
            else
            {
                WinControl = Controls[WinName];
            }
            return WinControl;
        }
        public void LoadFromWindow(Window W) {
            var A = Form.GetControls(W);
            UserControlLanguage WinControl = GetWindowControlLanguage(W);
            foreach (var B in A) 
            {
                var UserControl = GetUserControlLanguage(WinControl.Controls,B);

            }

            /*

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
