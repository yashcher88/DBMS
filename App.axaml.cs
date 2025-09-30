using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using DBMS.Classes;

namespace DBMS
{
    public partial class App : Application
    {
        public Store store = Program.store;
        public static App Instance { get; private set; }
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
            Instance = this;
        }

        public override void OnFrameworkInitializationCompleted()
        {
            base.OnFrameworkInitializationCompleted();
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new Start();
            }
        }
    }
}