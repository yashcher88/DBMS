using Avalonia.Controls;


namespace DBMS.Classes
{
    public class BaseForm : Window
    {
        public Store store;
        public BaseForm()
        {
            Opened += (_, _) =>
            {
                ApplyLanguage();
                ApplyStyles();
            };
            store = Program.store;
            //store.windows.Add(this);
        }
        public void Init()
        {
            store.LanguageObject.LoadFromWindow(this);
            store.LanguageObject.ApplyLanguageOnWindow(this);
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
