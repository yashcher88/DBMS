using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using DBMS.Classes;
using System;
using System.Collections.Generic;

namespace DBMS;

public partial class Connect : BaseWindow
{
    private string HidePassword = "***************";
    private string NowPassword = "";
    public Connection Connection;
    public Server Server;
    public Driver SelectedDriver;
    public List<string> Names = new List<string>();
    public Connect()
    {
        InitializeComponent();
        for (var i = 0; i < store.Drivers.Count; i++) 
        {
            DriverText.Items.Add(store.Drivers[i].Name);
        }
        NameText.ItemsSource = Names;


    }
    public void SelectDriver(Driver driver) 
    {
        SelectedDriver = driver;
        PortText.Text = driver.Info.DefaultPort.ToString();
        DBText.Text = driver.Info.DefaultDB;
        CodePageText.Text = driver.Info.DefaultDB;
//        ColorText.Color = #177caa;
    }
    public void SelectServer(int ServerIndex) 
    { 
        
    }

    public void FormClose(object sender, RoutedEventArgs e)
    {
        Close();
    }
    public void FormConnect(object sender, RoutedEventArgs e)
    {
        /*
         План:
        1)  Выполняем проверку соединения
            Если проверка выполнена необходимо добавить Server в список и Connection в список
         
         */
        Server S;
        if (Server == null)
        {
            S = new Server(
                NameText.Text,
                HostText.Text,
                Convert.ToInt32(PortText.Text),
                LoginText.Text,
                NowPassword,
                SelectedDriver,
                DBText.Text,
                isSavePassword.IsChecked ?? false,
                CodePageText.Text,
                ColorText.Color
            );
        }
        else 
        {
            S = Server.Clone();
            S.Name = NameText.Text;
            S.Password = NowPassword;
            S.DefaultDB = DBText.Text;
            S.SavePassword = isSavePassword.IsChecked ?? false;
            S.CodePage = CodePageText.Text;
            S.StateColor = ColorText.Color;
        }
        Connection = new Connection();
        Connection.Server = S;
        if (Connection.TestConnection()) 
        { 
            //Добавляем сервер
        }
        else
        {
            //Показываем ошибку
        }
    }
    public void FormAfterShow(object sender, EventArgs e)
    {
        //Загрузка списка серверов
        Names.Clear();
        for (var i = store.Servers.List.Count - 1; i >=0 ; i--)
        {
            Names.Add(store.Servers.List[i].Name);
        }
    }
    public void FormDriverChange(object sender, SelectionChangedEventArgs e)
    {
        SelectDriver(store.Drivers[DriverText.Items.IndexOf(e.AddedItems[0])]);
    }
    public void FormPasswordChange(object sender, RoutedEventArgs e)
    {
        NowPassword = PasswordText.Text;
    }
    public void FormServerChange(object sender, RoutedEventArgs e)
    {
        //SelectDriver();
    }
}