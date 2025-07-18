using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using DBMS.Classes;
using DBMS.Functions;
using System.ComponentModel;

namespace DBMS;

public partial class Main : BaseForm
{
    public Main()
    {
        InitializeComponent();
        Closing += (Window_Closed);
    }
    public void Window_Closed(object sender, CancelEventArgs e)
    {
        if (store.Start != null)
        {
            store.Start.Close();
        }
    }
    public void FormConnectToServer(object sender, RoutedEventArgs e)
    {

    }
    public void FormDisConnectFromServer(object sender, RoutedEventArgs e)
    {

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