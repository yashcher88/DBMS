using Avalonia.Controls;
using DBMS.Classes;
using DBMS.Functions;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace DBMS
{
    public partial class Start : BaseForm
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
            Init();
            BuildBlock.Text = $"Build version: " + (Assembly.GetEntryAssembly()?.GetName()?.Version?.ToString() ?? "1.0.0.0");
            StateText.Text = $"Loading languages";
            PackageBlock.Text = $"Package version: " + store.GetUserVersion();
            store.LoadLanguage();
            await Task.Delay(200);

            StateText.Text = $"Load default settings";
            //store.LoadSets();
            await Task.Delay(200);

            StateText.Text = $"Load servers";
            //store.LoadServers();
            await Task.Delay(200);

            StateText.Text = $"Load user settings";
            //store.LoadUserSets();
            await Task.Delay(200);

            StateText.Text = $"Load user styles";
            //store.LoadUserStyles();
            await Task.Delay(200);

            var main = new Main();
            main.Show();
            main.Init();
            Hide();
        }
    }
}