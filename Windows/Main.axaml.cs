using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using DBMS.Classes;
using DBMS.Functions;
using DBMS.WindowDocks;
using System.Collections.Generic;
using System.ComponentModel;


namespace DBMS;

public partial class Main : BaseWindow
{
    MainDockControl mainDockControl;
    public Main()
    {
        InitializeComponent();
        Closing += Window_Closed;
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
        //leftToolDock = new Dock.Model.Avalonia.Controls.ToolDock();

        var document = new ObjectExplorer();
        document.Id = "ObjectExplorer";
        document.Title = "Обозреватель объектов";
        mainDockControl.AddToolLeft(document);
    }
    public void FormCloseObjectExplorer(object sender, RoutedEventArgs e)
    {
        var document = new QueryWindow();
        document.Id = "QueryWindow";
        document.Title = "Query1";
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
        configureStore.Init();
    }
    public void FormShowSettings(object sender, RoutedEventArgs e)
    {
        Settings configureStore = new Settings();
        configureStore.Show();
        configureStore.Init();
    }
}