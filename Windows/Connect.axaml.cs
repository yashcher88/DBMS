using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using DBMS.Classes;
using DBMS.Functions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DBMS;

public partial class Connect : BaseWindow
{
    private string HidePassword = "***************";
    private string NowPassword = "";
    public Connection Connection;
    public Server Server;
    public int SelectedServerIndex = -1;
    public Driver SelectedDriver;
    public List<string> Names = new List<string>();
    public string[] Codes = FileUtils.GetCodePages();
    public Connect()
    {
        InitializeComponent();
        foreach (var node in store.Drivers.List) 
        {
            DriverText.Items.Add(node.Key);
        }
        CodePageText.ItemsSource = Codes;
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
        SelectedServerIndex = ServerIndex;
        var S = store.Servers.List[ServerIndex];
        NameText.SelectedItem = S.Name; //Не проставляется
        DriverText.SelectedIndex = DriverText.Items.IndexOf(S.driver.Name);
        HostText.Text = S.Host;
        PortText.Text = Convert.ToString(S.Port);
        LoginText.Text = S.Login;
        PasswordText.Text = HidePassword;
        if (S.SavePassword)
        {
            NowPassword = S.Password;
        }
        else 
        {
            NowPassword = "";
        }
        isSavePassword.IsChecked = S.SavePassword;
        DBText.Text = S.DefaultDB;
        CodePageText.Text = S.CodePage;
        ColorText.Color = S.StateColor;

    }

    public void FormClose(object sender, RoutedEventArgs e)
    {
        Close();
    }
    async public void FormConnect(object sender, RoutedEventArgs e)
    {
        /*
         План:
        1)  Выполняем проверку соединения
            Если проверка выполнена необходимо добавить Server в список и Connection в список
         
         */
        Server S;
        if (Server == null)
        {
            S = new Server();
            S.FillServer(
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
        Connection.NowDatabase = DBText.Text;
        var M = Connection.CheckConnection();
        if (M) 
        {
            //Добавляем сервер
            store.Servers.ChangeServer(S, SelectedServerIndex);
            store.SaveServers();
            Close();
        }
        else
        {
            //Показываем ошибку
            await Form.ShowErrorModalOk(this, Connection.GetLastError().Message);
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
        NameText.ItemsSource = Names;
        if (Names.Count > 0) { 
            SelectServer(Names.Count - 1);
        }

    }
    public void FormDriverChange(object sender, SelectionChangedEventArgs e)
    {
        SelectDriver(store.Drivers.List[e.AddedItems[0].ToString()]);
    }
    public void FormPasswordChange(object sender, RoutedEventArgs e)
    {
        NowPassword = PasswordText.Text;
    }
    public void FormServerChange(object sender, RoutedEventArgs e)
    {
        if (NameText.SelectedItem != null) 
        {
            for (var i = 0; i < store.Servers.List.Count; i++) 
            {
                if (store.Servers.List[i].Name == NameText.SelectedItem.ToString()) 
                {
                    SelectServer(i);
                    break;
                }
            }
        }
    }
}