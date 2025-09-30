using Avalonia.Controls;
using DBMS.Classes;
using DBMS.Functions;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace DBMS
{
    public partial class Start : BaseWindow
    {
        public Start()
        {
            InitializeComponent();
            store.Start = this;
        }
        public void AfterShow(object sender, EventArgs e)
        {
            Loading();
        }
        async public void Loading()
        {
            BuildBlock.Text = $"Build version: " + (Assembly.GetEntryAssembly()?.GetName()?.Version?.ToString() ?? "1.0.0.0");
            StateText.Text = $"Loading System Settings";
            store.LoadVersion();
            PackageBlock.Text = $"Package version: " + store.GetUserVersion();
            store.LoadSystemSettings();
            await Task.Delay(200);

            StateText.Text = $"Loading User Settings";
            store.LoadUserSettings();
            await Task.Delay(200);

            StateText.Text = $"Load files";
            store.LoadImages();
            await Task.Delay(200);

            StateText.Text = $"Load servers";
            store.LoadServers();
            await Task.Delay(200);

            StateText.Text = $"Apply styles";
            store.Sets.Style.ApplyStyleSettings();
            await Task.Delay(200);

            var main = new Main();
            main.InitializeDock();
            main.Show();
            Hide();
        }
    }
}