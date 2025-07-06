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
            store.LanguageLoadFromWindow(this);
            //store.windows.Add(this);
        }
        protected virtual void Init(BaseForm F)
        {
            store = F.store;
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
