using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using DBMS.Classes;
using DBMS.Classes.Base;
using Dock.Model.Core;
using Dock.Model.Mvvm.Core;
using Dock.Model.Avalonia.Controls;
using System.Security.Cryptography.X509Certificates;
using Avalonia.Interactivity;

namespace DBMS.WindowDocks;

public partial class ObjectExplorer : Tool
{
    public ObjectExplorer()
    {
        InitializeComponent();
    }
    public void FormConnectClick(object sender, RoutedEventArgs e)
    {
        var T = new Connect();
        T.ShowDialog(Program.store.Main);
    }
    public void FormDisconnectClick(object sender, RoutedEventArgs e)
    {
    }
    public void FormRefreshClick(object sender, RoutedEventArgs e)
    {
    }
    public void FormSearchClick(object sender, RoutedEventArgs e)
    {
    }

}