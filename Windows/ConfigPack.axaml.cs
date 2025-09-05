using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using DBMS.Classes;
using DBMS.Classes.Language.GridRows;
using DBMS.Enums;
using DBMS.Functions;
using HarfBuzzSharp;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace DBMS;

public partial class ConfigPack : BaseWindow
{

    public ConfigPack()
    {
        InitializeComponent();
    }

    /*Функции для Language*/
    
    public void FillLangGrid()
    {
        //LangGrid.Items.Add();
    }
    
    /* End of Функции для Language */

    /* Функции Формы */
    public void FormSavePackage(object sender, RoutedEventArgs e)
    {
        store.SavePack();
    }
    public void FormClose(object sender, RoutedEventArgs e)
    {
        Close();
    }
    
}