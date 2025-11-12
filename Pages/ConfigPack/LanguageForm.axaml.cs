using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using DBMS.Classes;

namespace DBMS.Pages;

public partial class LanguageForm : BaseUserControl
{
    InterfaceSettingLanguage ISetting;
    public LanguageForm()
    {
        InitializeComponent();
        ISetting = new InterfaceSettingLanguage(LangGrid, LangItems, store.Sets.LanguageList);
    }
    public void OnAttachedToVisualTree(object sender, VisualTreeAttachmentEventArgs e)
    {
        ISetting.Refresh();
    }
    public void FormAddLangList(object sender, RoutedEventArgs e)
    {
        ISetting.AddItem(); 
    }
    public void FormRenameLangList(object sender, RoutedEventArgs e)
    {
        ISetting.RenameItem();
    }
    public void FormDeleteLangList(object sender, RoutedEventArgs e)
    {
        ISetting.RemoveItem();
    }
    public void DataGrid_CellEditEnded(object sender, DataGridCellEditEndedEventArgs e) 
    {
        ISetting.ChangeCell(e);
    }
}