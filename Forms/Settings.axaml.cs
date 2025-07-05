using Avalonia.Controls;
using Avalonia.Interactivity;
using DBMS.Classes;
using DBMS.Functions;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;
using System.Reflection;

namespace DBMS;

public partial class Settings : BaseForm
{
    public Settings()
    {
        InitializeComponent();
    }
    public void FilterButtonTreeClick(object sender, RoutedEventArgs e)
    {
        //var r = Form.ShowErrorModalOk(this, "124124");
        Form.ToggleButton(sender, "filter", "unfilter");
    }
    public void FilterButtonGridClick(object sender, RoutedEventArgs e)
    {
        //var r = Form.ShowErrorModalOk(this, "124124");
        Form.ToggleButton(sender, "filter", "unfilter");
    }
}