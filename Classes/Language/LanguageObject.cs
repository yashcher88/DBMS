using Avalonia.Controls;
using DBMS.Classes.Language.Old;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;

namespace DBMS.Classes
{
    /*
     * Главный языковой объект
     * Содержит в себе список всех доступных языков     
     */
    public class LanguageObject
    {
        public Dictionary<string, LanguageElement> Languages = new Dictionary<string, LanguageElement>();
        public string DefaultLanguage = "Русский";
        public string SelectedLanguage;
        public LanguageObject() { 
            LanguageElement L = new LanguageElement();
            Languages.Add(DefaultLanguage, L);
            SelectedLanguage = DefaultLanguage;
        }
        public void LoadFromWindow(Window W)
        {
            foreach (var node in Languages)
            {
                node.Value.LoadFromWindow(W, node.Key == DefaultLanguage);
            }
        }
        public void LoadFromJson(JsonObject J)
        {

        }
        public JsonObject SaveToJson()
        {
            JsonObject J = new JsonObject();
            return J;
        }
    }
}
