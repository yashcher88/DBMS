using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using DBMS.Classes;

namespace DBMS.Pages;

public partial class StyleForm : BaseUserControl
{
    InterfaceSettingStyle ISetting;
    public StyleForm()
    {
        InitializeComponent();
        ISetting = new InterfaceSettingStyle(StyleGrid, StyleItems, store.Sets.StyleList);
    }
    public void OnAttachedToVisualTree(object sender, VisualTreeAttachmentEventArgs e)
    {
        ISetting.Refresh();
    }
    public void FormAddStyleList(object sender, RoutedEventArgs e)
    {
        ISetting.AddItem();
    }
    public void FormRenameStyleList(object sender, RoutedEventArgs e)
    {
        ISetting.RenameItem();
    }
    public void FormDeleteStyleList(object sender, RoutedEventArgs e)
    {
        ISetting.RemoveItem();
    }
    public void DataGrid_CellEditEnded(object sender, DataGridCellEditEndedEventArgs e)
    {
        ISetting.ChangeCell(e);
    }
}