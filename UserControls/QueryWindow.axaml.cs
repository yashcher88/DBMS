using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Documents;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using Avalonia.Threading;
using AvaloniaEdit;
using AvaloniaEdit.Highlighting;
using AvaloniaEdit.Highlighting.Xshd;
using DBMS.Classes;
using DBMS.Enums;
using DBMS.Functions;
using DocumentFormat.OpenXml.Bibliography;
using System;
using System.IO;
using System.Numerics;
using System.Reflection;
using System.Xml;

namespace DBMS.UserControls;

public partial class QueryWindow : BaseUserControl
{
    public Connection Connection;
    public object Form;
    public DispatcherTimer Timer;
    private int ShowingMessages;
    //private TextBlock QueryStateControl => this.FindControl<TextBlock>("QueryState");
    public QueryWindow()
    {
        Form = this;
        InitializeComponent();
        ResultSplitter.IsVisible = false;
        Result.IsVisible = false;
        Timer = new DispatcherTimer
        {
            Interval = TimeSpan.FromMilliseconds(100)
        };
        Timer.Tick += OnTimer;
        var reader = XmlReader.Create(AssetLoader.Open(new Uri("avares://DBMS/Sources/Syntax/postgresql.xshd")));
        var highlighting = HighlightingLoader.Load(reader, HighlightingManager.Instance);
        HighlightingManager.Instance.RegisterHighlighting(
            "PostgreSQL", new[] { ".pgsql", ".psql", ".sql" }, highlighting);

        QueryText.SyntaxHighlighting = highlighting;
    }
    public void AddMessage(int Id) 
    {
        Run R = new Run { Text = Connection.Messages[Id].Message };
        if (Connection.Messages[Id].ErrorType == ConnectionTypeError.Error) 
        { 
            R.Foreground = Brushes.Red;
        }
        Messages.Inlines.Add(R);
        Messages.Inlines.Add(new LineBreak());
        Messages.Inlines.Add(new LineBreak());
    }
    public void ShowResult() 
    {
        if (Connection.Messages.Count > 0) 
        {
            ResultSplitter.IsVisible = true;
            Result.IsVisible = true;
            while (ShowingMessages < Connection.Messages.Count) 
            {
                AddMessage(ShowingMessages);
                ShowingMessages++;
            }
            if (Connection.Results.Count > 0) 
            {
                Connection.Results[0].FillDataGrid(ResultGrid);
                ResultTab.IsVisible = true;
            }
            var rowDefinitions = MainGrid.RowDefinitions;

            if (rowDefinitions[1].Height.Value == 0) { 
                // Изменяем определения строк: 50% для первой, 4 для разделителя, 50% для третьей
                rowDefinitions[0].Height = new GridLength(1, GridUnitType.Star); // 50%
                rowDefinitions[1].Height = new GridLength(4); // Разделитель
                rowDefinitions[2].Height = new GridLength(1, GridUnitType.Star); // 50%
            }
        }
    }
    public void OnTimer(object sender, EventArgs e)
    {
        var S = System.DateTime.Now.Subtract(Connection.LastStart);
        QueryTime.Text = CConvert.SecsToString(S);
        ImageState.Source = store.Images["StateIcons.Executing." + (S.Milliseconds / 100)];
        ShowResult();
    }
    public void ClearResults() 
    {
        ShowingMessages = 0;
        ResultTab.IsVisible = false;
        ResultText.IsVisible = false;
        QueryPlan.IsVisible = false;
        Messages.Inlines.Clear();
        Connection.Results.Clear();
        Connection.Messages.Clear();
    }
    async public void ExecuteQuery(object sender, RoutedEventArgs e)
    {
        if (Connection != null)
        {
            ClearResults();
            Connection.LastStart = DateTime.Now;
            Timer.Start();
            Connection.State = ConnectionStateType.Executing;
            RefreshState();
            Connection.ReadNotice = true;
            string Batch = "";
            if (QueryText.SelectedText != "")
            {
                Batch = QueryText.SelectedText;
            }
            else
            {
                Batch = QueryText.Text;
            }
            await Connection.ExecuteAsync(Batch);
            RefreshState();
            ShowResult();
            Timer.Stop();
        }
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
                    ImageState.Source = store.Images["ButtonIcons.Connect"];
                    QueryTime.Text = "00:00:00";
                    break;
                case ConnectionStateType.Disconnected:
                    QueryState.Text = "Не подключено";
                    ImageState.Source = store.Images["ButtonIcons.Disconnect"];
                    QueryTime.Text = "00:00:00";
                    break;
                case ConnectionStateType.Executing:
                    QueryState.Text = "Выполняется";
                    QueryTime.Text = CConvert.SecsToString(System.DateTime.Now.Subtract(Connection.LastStart));
                    break;
                case ConnectionStateType.Complete:
                    QueryState.Text = "Выполнено";
                    ImageState.Source = store.Images["StateIcons.Complete"];
                    QueryTime.Text = CConvert.SecsToString(System.DateTime.Now.Subtract(Connection.LastStart));
                    break;
                case ConnectionStateType.CompleteError:
                    QueryState.Text = "Выполнено с ошибками";
                    ImageState.Source = store.Images["StateIcons.CompleteError"];
                    QueryTime.Text = CConvert.SecsToString(System.DateTime.Now.Subtract(Connection.LastStart));
                    break;
                case ConnectionStateType.Canceled:
                    QueryState.Text = "Отменено";
                    ImageState.Source = store.Images["StateIcons.Canceled"];
                    QueryTime.Text = CConvert.SecsToString(System.DateTime.Now.Subtract(Connection.LastStart));
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
            StatePanel.Background = new SolidColorBrush(Connection.Server.StateColor);
        }        
        RefreshState();
    }
    public void CancelQuery(object sender, RoutedEventArgs e)
    {

    }
}