using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.Markup.Xaml.Styling;
using DBMS.Classes;
using System;

namespace DBMS
{
    public partial class App : Application
    {
        public UserStyle Style { get; } = Program.store.Style;
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {

            Resources["UserColors"] = Program.store.Style.Colors;
            base.OnFrameworkInitializationCompleted();
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new Start();
            }
        }
    }
}