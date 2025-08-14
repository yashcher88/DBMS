using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using DBMS.Enums;

namespace DBMS.Classes
{
    public class DriverObjectNode
    {
        public string ObjId = "";
        public string Name = "";
        public string Caption = "";
        public string Hint = "";
        public ObjectTreeImage Image = ObjectTreeImage.Folder;
        public ObjectTreeNodeType NodeType = ObjectTreeNodeType.Unknown;
        public bool Expanded = false;
        public bool Wait = true;
        public bool Filtered = false;
        public int MinVersion = 0;
        public int MaxVersion = 2147483647;
        public List<string> Childs = new List<string>();
//        public DriverPopupLink PopupLink = null;
        public JsonObject SaveToJson()
        {
            JsonObject J = new JsonObject();
            J["Name"] = Name;
            J["Caption"] = Caption;
            J["Hint"] = Hint;
            J["ObjId"] = ObjId;
            //if (PopupLink != null) J["PopupLink"] = PopupLink.SaveToJson();
            return J;
        }
        public void LoadFromJson(JsonObject J)
        {
            Name = J["Name"].ToString();
            Caption = J["Caption"].ToString();
            Hint = J["Hint"].ToString();
            ObjId = J["ObjId"].ToString();
            /*            if (J["Tree"] != null)
                        {
                            Tree = new ParameterLink();
                            Tree.LoadFromJson(J["Tree"].AsObject());
                        }
                        if (J["One"] != null)
                        {
                            One = new ParameterLink();
                            One.LoadFromJson(J["One"].AsObject());
                        }
                        if (J["PopupLink"] != null)
                        {
                            PopupLink = new DriverPopupLink();
                            PopupLink.LoadFromJson(J["PopupLink"].AsObject());
                        }*/
        }
    }
}
