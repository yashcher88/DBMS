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
     public void ShowConfig(object sender, RoutedEventArgs e)
    {
        ConfigPack configureStore = new ConfigPack();
        configureStore.Show();
        configureStore.Init();
    }
    public void ShowSettings(object sender, RoutedEventArgs e)
    {
        Settings configureStore = new Settings();
        configureStore.Show();
        configureStore.Init();
    }
}