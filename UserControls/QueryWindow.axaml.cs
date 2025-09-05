using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using AvaloniaEdit;
using DBMS.Classes;
using DBMS.Enums;
using DBMS.Functions;
using Dock.Model.Avalonia.Controls;
using System;
using System.Numerics;

namespace DBMS.UserControls;

public partial class QueryWindow : BaseUserControl
{
    public Connection Connection;
    public object Form;
    //private TextBlock QueryStateControl => this.FindControl<TextBlock>("QueryState");
    public QueryWindow()
    {
        Form = this;
        InitializeComponent();
    }
    public void ExecuteQuery(object sender, RoutedEventArgs e)
    {

    }
    public void RefreshState() 
    {
        if (Connection != null) 
        {
            QueryServer.Text = Connection.Server.Host;
            QueryUser.Text = Connection.Server.Login;
            QueryDB.Text = Connection.NowDatabase;

            switch (Connection.State) 
            {
                case ConnectionStateType.Connected:
                    QueryState.Text = "Подключено";
                    ImageState.Source = new Bitmap(AssetLoader.Open(new Uri("avares://DBMS/Sources/ButtonIcons/Connect.png")));
                    QueryTime.Text = "00:00:00";
                    break;
                case ConnectionStateType.Disconnected:
                    QueryState.Text = "Не подключено";
                    ImageState.Source = new Bitmap(AssetLoader.Open(new Uri("avares://DBMS/Sources/ButtonIcons/Disconnect.png")));
                    QueryTime.Text = "00:00:00";
                    break;
                case ConnectionStateType.Executing:
                    QueryState.Text = "Выполняется";
                    //ImageState.Source = new Bitmap("/Sources/ButtonIcons/Connect.png");
                    QueryTime.Text = CConvert.SecsToString(System.DateTime.Now.Subtract(Connection.LastStart).Seconds);
                    break;
                case ConnectionStateType.Complete:
                    QueryState.Text = "Выполнено";
                    ImageState.Source = new Bitmap(AssetLoader.Open(new Uri("avares://DBMS/Sources/ButtonIcons/Complete.png")));
                    QueryTime.Text = CConvert.SecsToString(System.DateTime.Now.Subtract(Connection.LastStart).Seconds);
                    break;
                case ConnectionStateType.CompleteError:
                    QueryState.Text = "Выполнено с ошибками";
                    ImageState.Source = new Bitmap(AssetLoader.Open(new Uri("avares://DBMS/Sources/ButtonIcons/CompleteError.png")));
                    QueryTime.Text = CConvert.SecsToString(System.DateTime.Now.Subtract(Connection.LastStart).Seconds);
                    break;
                case ConnectionStateType.Canceled:
                    QueryState.Text = "Отменено";
                    ImageState.Source = new Bitmap("/Sources/ButtonIcons/CompleteError.png");
                    QueryTime.Text = CConvert.SecsToString(System.DateTime.Now.Subtract(Connection.LastStart).Seconds);
                    break;
            }

        }
    }
    async public void ConnectToServer(object sender, RoutedEventArgs e)
    {
        var T = new Connect();
        T.Init();
        await T.ShowDialog(Program.store.Main);
        if (T.Connection != null) 
        { 
            Connection = T.Connection;
        }
        RefreshState();
    }
    public void CancelQuery(object sender, RoutedEventArgs e)
    {

    }
}