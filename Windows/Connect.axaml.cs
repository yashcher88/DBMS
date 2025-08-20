using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using DBMS.Classes;
using System;

namespace DBMS;

public partial class Connect : BaseWindow
{
    private string HidePassword = "***************";
    public Connect()
    {
        InitializeComponent();
        for (var i = 0; i < store.Drivers.Count; i++) 
        {
            DriverText.Items.Add(store.Drivers[i].Name);
        }
        
    }
    public void FormClose(object sender, RoutedEventArgs e)
    {
        Close();
    }
    public void FormConnect(object sender, RoutedEventArgs e)
    {
        //Close();
    }
    public void FormAfterShow(object sender, EventArgs e)
    {
        
    }
}