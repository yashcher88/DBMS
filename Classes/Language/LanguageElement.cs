using Avalonia.Controls;
using System.Collections.Generic;

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
            Window.FillAsWindow(W, isRewrite);
            Window.LoadFromWindow(W, isRewrite);
        }
    }
}
