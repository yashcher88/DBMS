using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using DBMS.Classes;
using DBMS.Functions;
using HarfBuzzSharp;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml.Linq;

namespace DBMS;


public partial class ConfigPack : BaseForm
{
    private bool ShowDeleted = false;
    public ConfigPack()
    {
        InitializeComponent();
        FillLangList();
        FillLangTree();
    }
    public void FillLangList()
    {
        LangList.Items.Clear();
        foreach (var node in store.LanguageObject.Languages)
        {
            LangList.Items.Add(node.Key);
            LangFormGrid.Columns.Add(new DataGridTextColumn { Header = node.Key });
            LangRefGrid.Columns.Add(new DataGridTextColumn { Header = node.Key });
        }
    }
    public int RenameLangList(string New, string Old) 
    {
        int i = 0;
        foreach (var node in store.LanguageObject.Languages) {
            if (node.Key == Old) 
            {
                break;
            }
            i = i + 1;
        }
        LangFormGrid.Columns[i + 1].Header = New;
        LangRefGrid.Columns[i + 1].Header = New;
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
                //LangTree.Items[index].
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
    public void FillLangGrid() 
    { 
        
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
            if ((LangTree.SelectedItem as TreeViewItem).Parent != null)
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

    /* Функции Формы */
    public void FormSavePackage(object sender, RoutedEventArgs e)
    {
        store.SavePack();
    }
    public void FormClose(object sender, RoutedEventArgs e)
    {
        Close();
    }
    public void FormAddToLangList(object sender, RoutedEventArgs e)
    {
        Form.EditItemList(LangList, LangList.Items.Add(""), RenameLangList);
    }
    public void FormRenameItemLangList(object sender, RoutedEventArgs e)
    {
        if (LangList.SelectedIndex >= 0)
        { 
            Form.EditItemList(LangList, LangList.SelectedIndex, RenameLangList);
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
        FillLangTree();
    }
    public void FormShowHideLangTree(object sender, RoutedEventArgs e)
    {
        ShowDeleted = false;
        FillLangTree();
    }
    public void FormAddLangRefGrid(object sender, RoutedEventArgs e)
    {

    }
    public void FormDelLangRefGrid(object sender, RoutedEventArgs e)
    {

    }
}