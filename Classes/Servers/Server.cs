using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace DBMS.Classes
{
    public class Server
    {
        public string Name;

        public Driver Driver;
        public string Host;
        public int Port;
        public string Login;
        public string Password;
        
        public string DefaultDB;
        public bool SavePassword;
        public string CodePage;
        public Avalonia.Media.Color StateColor;

        public DateTime LastConnection;
        public ServerStatistic Statistic;


        public Server(string _name, string _host, int _port, string _login, string _password, Driver _driver, string _defaultDB, bool _savePassword, string _codepage, Avalonia.Media.Color _statecolor)
        {
            Host = _host;
            Port = _port;
            Login = _login;
            Password = _password;
            Driver = _driver;
            DefaultDB = _defaultDB;
            SavePassword = _savePassword;
            CodePage = _codepage;
            StateColor = _statecolor;
            if (_name == "")
            {
                Name = _login + "@" + _host + ":" + _port;
            }
            else 
            {
                Name = _name;
            }
        }

        public JsonObject SaveServerToJson()
        {
            JsonObject J = new JsonObject();
            J["Host"] = Host;
            J["Port"] = Port;
            J["Login"] = Login;
            J["Password"] = Password;
            J["Driver"] = Driver.DriverType;
            J["DefaultDB"] = DefaultDB;
            J["SavePassword"] = SavePassword.ToString();
            J["CodePage"] = CodePage;
            J["StateColor"] = StateColor.ToString();
            return J;
        }
        public void LoadServerFromJson(JsonNode J)
        {
            Host = J["Host"].ToString();
            J["Port"] = Port;
            J["Login"] = Login;
            J["Password"] = Password;
            J["Driver"] = Driver.DriverType;
            J["DefaultDB"] = DefaultDB;
            J["SavePassword"] = SavePassword.ToString();
            J["CodePage"] = CodePage;
            J["StateColor"] = StateColor.ToString();
        }
        public Server Clone() 
        {
            Server S = new Server(
                Name,
                Host,
                Port,
                Login,
                Password,
                Driver,
                DefaultDB,
                SavePassword,
                CodePage,
                StateColor
            );
            return S;
        }
    }
}
