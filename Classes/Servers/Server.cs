using DBMS.Functions;
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

        public Driver driver;
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


        public void FillServer(string _name, string _host, int _port, string _login, string _password, Driver _driver, string _defaultDB, bool _savePassword, string _codepage, Avalonia.Media.Color _statecolor)
        {
            Host = _host;
            Port = _port;
            Login = _login;
            Password = _password;
            driver = _driver;
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
            J["Name"] = Name;
            J["Host"] = Host;
            J["Port"] = Port;
            J["Login"] = Login;
            J["Password"] = CConvert.Encrypt(Password);
            J["Driver"] = driver.Name;
            J["DefaultDB"] = DefaultDB;
            J["SavePassword"] = SavePassword.ToString();
            J["CodePage"] = CodePage;
            J["StateColor"] = StateColor.ToString();
            return J;
        }
        public void LoadServerFromJson(JsonNode J)
        {
            Name = J["Name"].ToString();
            Host = J["Host"].ToString();
            Port = Convert.ToInt32(J["Port"].ToString());
            Login = J["Login"].ToString();
            Password = CConvert.Decrypt(J["Password"].ToString());
            driver = Program.store.Drivers.List[J["Driver"].ToString()];
            DefaultDB = J["DefaultDB"].ToString();
            SavePassword =  Convert.ToBoolean(J["SavePassword"].ToString());
            CodePage = J["CodePage"].ToString();
            StateColor = Avalonia.Media.Color.Parse(J["StateColor"].ToString());
        }
        public Server Clone() 
        {
            Server S = new Server();
            S.FillServer(Name,
                Host,
                Port,
                Login,
                Password,
                driver,
                DefaultDB,
                SavePassword,
                CodePage,
                StateColor);
            return S;
        }
    }
}
