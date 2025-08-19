using DBMS.Enums;
using DBMS.Functions;
using System.Collections.Generic;
using System.Text.Json.Nodes;

namespace DBMS.Classes
{
    public class DriverForm
    {
        public List<ParameterLinkType> Caption = new List<ParameterLinkType>();
        public ObjectTreeImage Image;
        public List<DriverFormPage> Pages = new List<DriverFormPage>();
        public bool WithTopControl = false;
        public List<DriverFormScript> Scripts = new List<DriverFormScript>();
        public void LoadFromJson(JsonObject J)
        {
            Caption.Clear();
            for (var i = 0; i < J["Caption"].AsArray().Count; i++) 
            { 
                var M = new ParameterLinkType();
                M.LoadFromJson(J["Caption"].AsArray()[i].AsObject());
                Caption.Add(M);
            }
            Image = CConvert.StringToObjectTreeImage(J["Image"].ToString());
            Pages.Clear();
            for (var i = 0; i < J["Pages"].AsArray().Count; i++)
            {
                var P = new DriverFormPage();
                P.LoadFromJson(J["Pages"].AsArray()[i].AsObject());
                Pages.Add(P);
            }
            Scripts.Clear();
            for (var i = 0; i < J["Scripts"].AsArray().Count; i++)
            {
                var P = new DriverFormScript();
                P.LoadFromJson(J["Scripts"].AsArray()[i].AsObject());
                Scripts.Add(P);
            }
            WithTopControl = J["WithTopControl"].ToString() == "true";
        }
        public JsonObject SaveToJson()
        {
            JsonObject J = new JsonObject();
            J["Caption"] = new JsonArray();
            for (var i = 0; i < Caption.Count; i++) 
            {
                J["Caption"].AsArray().Add(Caption[i].SaveToJson());
            }
            J["Image"] = CConvert.ObjectTreeImageToString(Image);
            J["Pages"] = new JsonArray();
            for (var i = 0; i < Caption.Count; i++)
            {
                J["Pages"].AsArray().Add(Pages[i].SaveToJson());
            }
            J["Scripts"] = new JsonArray();
            for (var i = 0; i < Caption.Count; i++)
            {
                J["Scripts"].AsArray().Add(Scripts[i].SaveToJson());
            }
            J["WithTopControl"] = WithTopControl;
            return J;
        }
    }
}
