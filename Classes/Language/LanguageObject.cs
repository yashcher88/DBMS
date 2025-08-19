using Avalonia.Controls;
using DBMS.Functions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public void LoadObjectFromJson(JsonObject J)
        {
            Languages.Clear();
            bool isFirst = true;
            foreach (var node in J.AsObject()) 
            {
                LanguageElement LE = new LanguageElement();
                LE.LoadFromJson(node.Value.AsObject());
                if (isFirst) {
                    DefaultLanguage = node.Key;
                    isFirst = false;
                }
                Languages.Add(node.Key, LE);
            }
        }
        public JsonObject SaveObjectToJson()
        {
            JsonObject J = new JsonObject();
            foreach (var node in Languages)
            {
                J[node.Key] = node.Value.SaveToJson();
            }
            return J;
        }
        public void ApplyLanguageOnWindow(Window W) 
        {
            string WName = W.GetType().Name;
            if (Languages.ContainsKey(SelectedLanguage)) { 
                if (Languages[SelectedLanguage].Windows.ContainsKey(WName))
                {
                    Languages[SelectedLanguage].Windows[WName].WriteToWindow(W);
                }
            }
        }
        public string GetLanguageFromList(string Key) 
        {
            return Languages[SelectedLanguage].List[Key];
        }
        public void ChangeLanguage(string Language) 
        {
            if (!Languages.ContainsKey(Language)) 
            {
                FileUtils.Error("Указываемый язык " + Language + " недоступен");
            }
            else 
            { 
                SelectedLanguage = Language;
            }
        }
        public void SetIsDelete(string WindowName, string ControlName,bool deleted)
        {
            foreach (var node in Languages)
            {
                if (ControlName != null)
                {
                    node.Value.Windows[WindowName].LanguageControls[ControlName].isDelete = deleted;
                }
                else 
                {
                    node.Value.Windows[WindowName].isDelete = deleted;
                }
            }
        }
        public void RenameLanguage(string OldLanguage, string NewLanguage) 
        {
            if (OldLanguage != "")
            {
                var L = Languages[OldLanguage];
                Languages.Remove(OldLanguage);
                Languages.Add(NewLanguage, L);
            }
            else
            {
                AddLanguage(NewLanguage);
            }
        }
        public void AddLanguage(string NewLanguage) 
        {
            Languages.Add(NewLanguage, Languages[DefaultLanguage].CloneElement());
        }
    }
}
