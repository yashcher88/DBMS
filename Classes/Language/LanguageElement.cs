using Avalonia.Controls;
using System.Collections.Generic;
using System.Text.Json.Nodes;

namespace DBMS.Classes
{
    public class LanguageElement
    {
        /*
         * Конкретный язык содержит в себе два свойства - Windows, это все окна которые есть в системе
         * List - Дополнительный справочник с переводами на этот язык
         */
        public Dictionary<string, LanguageWindow> Windows = new Dictionary<string, LanguageWindow>();
        public Dictionary<string, string> List = new Dictionary<string, string>();
        public void LoadFromWindow(Window W, bool isRewrite)
        {
            LanguageWindow Window;
            string WName = W.GetType().Name;
            if (Windows.ContainsKey(WName))
            {
                Window = Windows[WName];
            }
            else
            {
                Window = new LanguageWindow();
                Windows.Add(WName, Window);
            }
            Window.ReadFromWindow(W, isRewrite);
        }
        public void LoadFromJson(JsonObject J)
        {
            if (J["Windows"] != null) 
            {
                Windows.Clear();
                foreach (var node in J["Windows"].AsObject()) 
                {
                    LanguageWindow LW = new LanguageWindow();
                    LW.LoadWindowFromJson(node.Value.AsObject());
                    Windows.Add(node.Key, LW);
                }
            }
            if (J["List"] != null)
            {
                List.Clear();
                foreach (var node in J["List"].AsObject())
                {
                    List.Add(node.Key,node.Value.ToString());
                }
            }
        }
        public JsonObject SaveToJson()
        {
            JsonObject J = new JsonObject();
            J["Windows"] = new JsonObject();
            foreach (var node in Windows) 
            {
                J["Windows"][node.Key] = node.Value.SaveWindowToJson();
            }
            J["List"] = new JsonObject();
            foreach (var node in List)
            {
                J["List"][node.Key] = node.Value;
            }
            return J;
        }
        public LanguageElement CloneElement() 
        {
            LanguageElement languageElement = new LanguageElement();
            languageElement.Windows = new Dictionary<string, LanguageWindow>();
            languageElement.List = new Dictionary<string, string>();

            foreach (var node in Windows)
            {
                languageElement.Windows[node.Key] = node.Value.CloneWindow();
            }
            foreach (var node in List)
            {
                languageElement.List[node.Key] = node.Value;
            }

            return languageElement;
        }
    }
}
