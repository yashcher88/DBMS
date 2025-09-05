using Avalonia.Controls;
using Dock.Model.Core;
using Dock.Model.Mvvm.Controls;
using Dock.Model.Mvvm.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Classes
{
    public class BaseUserControl : UserControl
    {
        public Store store;
        public UserStyle Style { get; } = Program.store.Style;
        public BaseUserControl()
        {
            /*Opened += (_, _) =>
            {
                ApplyLanguage();
                ApplyStyles();
            };*/
            store = Program.store;
            //store.windows.Add(this);
        }
        public void Init()
        {
            store.LanguageObject.LoadFromUserControl(this);
            store.LanguageObject.ApplyLanguageOnUserControl(this);
            //store.interfaceLanguage.ReadFromWindow(this);
        }
        protected virtual void ApplyLanguage()
        {
            //store.interfaceLanguage.WriteToWindow(this);
            // Логика применения локализации, например:
            // this.FindControl<TextBlock>("TitleText").Text = Localization.Get("MainWindow_Title");
        }
        protected virtual void ApplyStyles()
        {
            // Логика применения стилей, например смена темы
            // this.Styles.Add(new FluentTheme { Mode = FluentThemeMode.Dark });
        }
    }
}
