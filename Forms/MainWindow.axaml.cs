using Avalonia.Controls;
using DBMS.Classes;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace DBMS
{
    public partial class MainWindow : BaseForm
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public void AfterShow(object sender, EventArgs e)
        {
            Init();
        }
        public async void Init()
        {
            BuildBlock.Text = $"Build version: " + (Assembly.GetEntryAssembly()?.GetName()?.Version?.ToString() ?? "1.0.0.0");
            StateText.Text = $"Loading drivers";
            store.LoadPack();
            PackageBlock.Text = $"Package version: " + store.versionPack.ToString();
            await Task.Delay(200);

            StateText.Text = $"Load default settings";
            store.LoadSets();
            await Task.Delay(200);

            StateText.Text = $"Load servers";
            store.LoadServers();
            await Task.Delay(200);

            StateText.Text = $"Load user settings";
            store.LoadUserSets();
            await Task.Delay(200);

            StateText.Text = $"Load user styles";
            store.LoadUserStyles();
            await Task.Delay(200);

            var mainWindow = new Main();
            mainWindow.Init(this);
            mainWindow.Show();
            Hide();
        }
    }
}