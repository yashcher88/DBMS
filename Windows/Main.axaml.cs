using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using DBMS.Classes;
using DBMS.Functions;
using DBMS.UserControls;
using System.Collections.Generic;
using System.ComponentModel;
using Dock.Model.Avalonia.Controls;

namespace DBMS;

public partial class Main : BaseWindow
{
    MainDockControl mainDockControl;
    public Main()
    {
        InitializeComponent();
        Closing += Window_Closed;
        store.Main = this;
    }
    public void InitializeDock()
    {
        mainDockControl = new MainDockControl(MainDock);
    }
    public void Window_Closed(object sender, CancelEventArgs e)
    {
        if (store.Start != null)
        {
            store.Start.Close();
        }
    }
    public void FormShowObjectExplorer(object sender, RoutedEventArgs e)
    {
        var V = new ObjectExplorer();
        var document = new Tool
        {
            Id = "ObjectExplorer",
            Title = "Обозреватель объектов",
            Content = V
        };
        mainDockControl.AddToolLeft(document);
    }
    public void FormCloseObjectExplorer(object sender, RoutedEventArgs e)
    {
        var Q = new QueryWindow();
        var document = new Document
        {
            Id = "QueryWindow",
            Title = "Query1",
            Content = Q
        };
        mainDockControl.AddDocument(document);
    }
    public void FormCreateQuery(object sender, RoutedEventArgs e)
    {

    }
    public void FormOpenQuery(object sender, RoutedEventArgs e)
    {

    }
    public void FormShowConfig(object sender, RoutedEventArgs e)
    {
        ConfigPack configureStore = new ConfigPack();
        configureStore.Show();
    }
    public void FormShowSettings(object sender, RoutedEventArgs e)
    {
        Settings configureStore = new Settings();
        configureStore.Show();
    }
}