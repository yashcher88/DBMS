using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using DBMS.Classes;

namespace DBMS;

public partial class Connect : BaseWindow
{
    public Connect()
    {
        InitializeComponent();
    }
    public void FormClose(object sender, RoutedEventArgs e)
    {
        Close();
    }
    public void FormConnect(object sender, RoutedEventArgs e)
    {
        //Close();
    }
}