using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using DBMS.Classes;
using DBMS.Functions;
using HarfBuzzSharp;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DBMS;


public partial class ConfigPack : BaseForm
{
    public ConfigPack()
    {
        InitializeComponent();
        FillLangList();
    }
    public void FillLangList() 
    { 
        LangList.Items.Clear();
        foreach (var node in store.LanguageObject.Languages)
        {
            LangList.Items.Add(node.Key);
        }
    }
    public int UpdateLangList(string NewValue, string OldValue) 
    {
        if (OldValue != NewValue) {
            var L = store.LanguageObject.Languages[OldValue];
            store.LanguageObject.Languages.Remove(OldValue);
            store.LanguageObject.Languages.Add(NewValue, L);
        }
        return 0;
    }
    public void SavePackage(object sender, RoutedEventArgs e)
    {
        store.SavePack();
    }
    public void Close(object sender, RoutedEventArgs e)
    {
        Close();
    }
    public void AddToLangList(object sender, RoutedEventArgs e)
    {
        Form.EditItemList(LangList, LangList.Items.Add(""), UpdateLangList);
    }
    public void RenameItemLangList(object sender, RoutedEventArgs e)
    {
        if (LangList.SelectedIndex >= 0) { 
            Form.EditItemList(LangList, LangList.SelectedIndex, UpdateLangList);
        }
    }
    public void DelFromLangList(object sender, RoutedEventArgs e)
    {

    }
    public void HideLangTree(object sender, RoutedEventArgs e)
    {

    }
    public void UnHideLangTree(object sender, RoutedEventArgs e)
    {

    }
    public void ShowUnHideLangTree(object sender, RoutedEventArgs e)
    {

    }
    public void ShowHideLangTree(object sender, RoutedEventArgs e)
    {

    }
    public void AddLangRefGrid(object sender, RoutedEventArgs e)
    {

    }
    public void DelLangRefGrid(object sender, RoutedEventArgs e)
    {

    }
}