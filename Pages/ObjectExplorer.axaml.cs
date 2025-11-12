using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using DBMS.Classes;
using DBMS.Enums;
using Dock.Model.Avalonia.Controls;
using Dock.Model.Core;
using Dock.Model.Mvvm.Core;
using System.Collections.ObjectModel;
using System.Security.Cryptography.X509Certificates;

namespace DBMS.Pages;

public partial class ObjectExplorer : BaseUserControl
{
    public ObservableCollection<DriverTreeElement> Nodes { get; set; }
    public ObjectExplorer()
    {
        InitializeComponent();
        Nodes = new ObservableCollection<DriverTreeElement>();
        MainTree.ItemsSource = Nodes;
    }
    async public void FormConnectClick(object sender, RoutedEventArgs e)
    {
        var T = new Connect();
        await T.ShowDialog(Program.store.Main);
        if (T.Connection != null) 
        {
            DriverTreeElement M = new DriverTreeElement();
            M._name = T.Connection.Server.Name + " (" + T.Connection.Server.driver.Name + " - " + T.Connection.Server.Login + ")";
            M.Image = ObjectTreeImage.Server;
            Nodes.Add(M);
            //M.Image = "Server.bmp";
            //string S = ;
            //MainTree.Items.Add(M);
        }
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