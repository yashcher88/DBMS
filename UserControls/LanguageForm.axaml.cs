using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Styling;
using DBMS.Classes;
using DBMS.Classes.ProgramSetting.Language;
using DBMS.Classes.ProgramSetting.Language.GridRows;
using DBMS.Enums;
using DBMS.Functions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace DBMS.UserControls;

public partial class LanguageForm : BaseUserControl
{
    public ObservableCollection<LanguageFormGridRow> LangFormRows { get; set; }
    private bool ShowDeleted = false;
    public string SelectedLangWindow = "";
    public string SelectedLangControl = null;
    public LanguageForm()
    {
        InitializeComponent();
        LangFormRows = new ObservableCollection<LanguageFormGridRow>();
        LangFormGrid.ItemsSource = LangFormRows;
        LangFormGrid.Columns.Add(new DataGridTextColumn
        {
            Header = "Свойство",
            Binding = new Avalonia.Data.Binding("Name"),
            Width = DataGridLength.Auto
        });
        FillLangList();
        FillLangTree();
        FillRefList();
    }
    public void AddColumnDataGrid(string colName)
    {
        var i = LangFormGrid.Columns.Count - 1;
        LangFormGrid.Columns.Add(new DataGridTextColumn
        {
            Header = colName,
            Binding = new Avalonia.Data.Binding($"Fields[{i}]")
        });
    }
    public void FillLangList()
    {
        LangList.Items.Clear();
        foreach (var node in store.LanguageObject.Languages)
        {
            LangList.Items.Add(node.Key);
            AddColumnDataGrid(node.Key);
            LangRefGrid.Columns.Add(new DataGridTextColumn { Header = node.Key });
        }
    }
    public void FillRefList()
    {

    }
    public int RenameLangList(string New, string Old)
    {
        int i = 0;
        foreach (var node in store.LanguageObject.Languages)
        {
            if (node.Key == Old)
            {
                break;
            }
            i = i + 1;
        }
        if (LangFormGrid.Columns.Count <= i + 1)
        {
            AddColumnDataGrid(New);
            LangRefGrid.Columns.Add(new DataGridTextColumn { Header = New });
        }
        else
        {
            LangFormGrid.Columns[i + 1].Header = New;
            LangRefGrid.Columns[i + 1].Header = New;
        }
        store.LanguageObject.RenameLanguage(Old, New);
        return 0;
    }
    public void FillLangTree()
    {
        LangTree.Items.Clear();
        foreach (var WNode in store.LanguageObject.Languages[store.LanguageObject.DefaultLanguage].Windows)
        {
            if (!(!ShowDeleted && WNode.Value.isDelete))
            {
                TreeViewItem _block = new TreeViewItem();

                _block.Header = WNode.Key;
                var index = LangTree.Items.Add(_block);
                if (WNode.Value.isDelete)
                {
                    _block.Classes.Add("disable");
                }
                foreach (var CNode in WNode.Value.LanguageControls)
                {
                    if (!(!ShowDeleted && CNode.Value.isDelete))
                    {
                        TreeViewItem _blockControl = new TreeViewItem();

                        _blockControl.Header = CNode.Key;
                        _block.Items.Add(_blockControl);
                        if (CNode.Value.isDelete)
                        {
                            _blockControl.Classes.Add("disable");
                        }
                    }
                }
            }
        }
    }
    public void SetHideLangTree(bool isHide)
    {
        if (LangTree.SelectedItem != null)
        {
            if (isHide)
            {
                (LangTree.SelectedItem as TreeViewItem).Classes.Add("disable");
            }
            else
            {
                (LangTree.SelectedItem as TreeViewItem).Classes.Remove("disable");
            }
            if ((LangTree.SelectedItem as TreeViewItem).Parent.GetType().Name == "TreeViewItem")
            {
                store.LanguageObject.SetIsDelete(((LangTree.SelectedItem as TreeViewItem).Parent as TreeViewItem).Header.ToString(), (LangTree.SelectedItem as TreeViewItem).Header.ToString(), isHide);
                if (!ShowDeleted && isHide)
                {
                    ((LangTree.SelectedItem as TreeViewItem).Parent as TreeViewItem).Items.Remove(LangTree.SelectedItem as TreeViewItem);
                }
            }
            else
            {
                store.LanguageObject.SetIsDelete((LangTree.SelectedItem as TreeViewItem).Header.ToString(), null, isHide);
                if (!ShowDeleted && isHide)
                {
                    LangTree.Items.Remove(LangTree.SelectedItem as TreeViewItem);
                }
            }
        }
    }
    public void FillRowsByControl(LanguageControl C)
    {

        //Rows.
    }
    public void SetParam(UserControlProperty P, UserControlProperty CP, ref List<string> L, string S)
    {
        if (CP.HasFlag(P))
        {
            if (L == null)
            {
                L = new List<string>();
            }
            L.Add(S);
        }
    }
    public void AddRowGrid(List<string> L, string S)
    {
        if (L != null)
        {
            LanguageFormGridRow GR = new LanguageFormGridRow();
            GR.Name = S;
            GR.Fields = L;
            LangFormRows.Add(GR);
        }
    }
    public void SetIndexListString(List<string> L, int Index, string Value)
    {
        if (Index >= 0)
        {
            for (int i = L.Count; i <= Index; i++)
            {
                L.Add(L[0]);
            }
            L[Index] = Value;
        }
    }
    
    public void FormAddToLangList(object sender, RoutedEventArgs e)
    {
        Functions.Form.EditItemList(LangList, LangList.Items.Add(""), RenameLangList);
    }
    public void FormRenameItemLangList(object sender, RoutedEventArgs e)
    {
        if (LangList.SelectedIndex >= 0)
        {
            Functions.Form.EditItemList(LangList, LangList.SelectedIndex, RenameLangList);
        }
    }
    public void FormLangFormGridCellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
    {
        if (e.EditAction == DataGridEditAction.Commit)
        {
            var textBox = e.EditingElement as TextBox;
            string newValue = textBox?.Text ?? string.Empty;
            int rowIndex = e.Row.Index;
            int colIndex = e.Column.DisplayIndex;
            SetIndexListString(LangFormRows[rowIndex].Fields, colIndex - 1, newValue);
            if (colIndex > 0)
            {
                if (SelectedLangControl == null)
                {
                    store.LanguageObject.Languages[e.Column.Header.ToString()].Windows[SelectedLangWindow].SetProperty(LangFormRows[rowIndex].Name, newValue);
                }
                else
                {
                    store.LanguageObject.Languages[e.Column.Header.ToString()].Windows[SelectedLangWindow].LanguageControls[SelectedLangControl].SetProperty(LangFormRows[rowIndex].Name, newValue);
                }
            }
        }
    }
    public void FormLangTreeSelection(object sender, SelectionChangedEventArgs e)
    {
        List<string> LText = null;
        List<string> LHeader = null;
        List<string> LContent = null;
        List<string> LToolTip = null;
        List<string> LTitle = null;
        List<string> LWaterMark = null;
        LanguageControl L;
        if (e.AddedItems.Count > 0)
        {
            LangFormRows.Clear();
            var sel = (LangTree.SelectedItem as TreeViewItem);
            string W;
            string C;

            if (sel.Parent.GetType().Name == "TreeViewItem")
            {
                W = (sel.Parent as TreeViewItem).Header.ToString();
                C = sel.Header.ToString();
            }
            else
            {
                W = sel.Header.ToString();
                C = null;
            }
            SelectedLangWindow = W;
            SelectedLangControl = C;
            foreach (var node in store.LanguageObject.Languages)
            {
                if (C != null)
                {
                    L = node.Value.Windows[W].LanguageControls[C];
                }
                else
                {
                    L = node.Value.Windows[W];
                }
                SetParam(UserControlProperty.Text, L.ControlProperty, ref LText, L.Text);
                SetParam(UserControlProperty.Content, L.ControlProperty, ref LContent, L.Content);
                SetParam(UserControlProperty.Header, L.ControlProperty, ref LHeader, L.Header);
                SetParam(UserControlProperty.ToolTip, L.ControlProperty, ref LToolTip, L.ToolTip);
                SetParam(UserControlProperty.Title, L.ControlProperty, ref LTitle, L.Title);
                SetParam(UserControlProperty.WaterMark, L.ControlProperty, ref LWaterMark, L.WaterMark);
            }
            AddRowGrid(LText, "Text");
            AddRowGrid(LContent, "Content");
            AddRowGrid(LHeader, "Header");
            AddRowGrid(LToolTip, "ToolTip");
            AddRowGrid(LTitle, "Title");
            AddRowGrid(LWaterMark, "WaterMark");
        }
    }
    public void FormDelFromLangList(object sender, RoutedEventArgs e)
    {
        if (LangList.SelectedIndex >= 0)
        {
            LangList.Items.Remove(LangList.SelectedItem);
            store.LanguageObject.Languages.Remove(LangList.SelectedItem.ToString());
        }
    }
    public void FormHideLangTree(object sender, RoutedEventArgs e)
    {
        SetHideLangTree(true);
    }
    public void FormUnHideLangTree(object sender, RoutedEventArgs e)
    {
        SetHideLangTree(false);
    }
    public void FormShowUnHideLangTree(object sender, RoutedEventArgs e)
    {
        ShowDeleted = true;
        LangTreePopupShowWithRemoved.IsVisible = false;
        LangTreePopupRestore.IsVisible = true;
        LangTreePopupHideRemoved.IsVisible = true;
        FillLangTree();
    }
    public void FormShowHideLangTree(object sender, RoutedEventArgs e)
    {
        ShowDeleted = false;
        LangTreePopupShowWithRemoved.IsVisible = true;
        LangTreePopupRestore.IsVisible = false;
        LangTreePopupHideRemoved.IsVisible = false;
        FillLangTree();
    }
    public void FormAddLangRefGrid(object sender, RoutedEventArgs e)
    {
        //LangRefGrid.
    }
    public void FormDelLangRefGrid(object sender, RoutedEventArgs e)
    {

    }
}