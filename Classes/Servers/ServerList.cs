using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace DBMS.Classes
{
    public class ServerList
    {
        public List<Server> List = new List<Server>();
        public Server FindServer(string Host, int Port, string Login, Driver driver) 
        {
            for (int i = 0; i < List.Count; i++) 
            {
                if ((List[i].Host == Host) && (List[i].Port == Port) && (List[i].Login == Login) && (List[i].driver == driver)) 
                { 
                    return List[i];
                }
            }
            return null;
        }
        public void ChangeServer(Server NewServer, int OldServerIndex = -1) 
        {
            /*Нужно искать по Хосту+Логин+Порт+Драйвер*/
            if (OldServerIndex != -1 &&
                NewServer.Host == List[OldServerIndex].Host &&
                NewServer.Login == List[OldServerIndex].Login &&
                NewServer.Port == List[OldServerIndex].Port &&
                NewServer.driver == List[OldServerIndex].driver
                )
            {
                var S = List[OldServerIndex];
                List.RemoveAt(OldServerIndex);
                S.Name = NewServer.Name;
                S.StateColor = NewServer.StateColor;
                S.SavePassword = NewServer.SavePassword;
                S.Password = NewServer.Password;
                S.CodePage = NewServer.CodePage;
                S.DefaultDB = NewServer.DefaultDB;
                List.Add(S);
            }
            else 
            {
                List.Add(NewServer);
            }
        }
        public JsonArray SaveObjectToJson()
        {
            JsonArray J = new JsonArray();
            for (int i = 0; i < List.Count; i++) 
            {
                J.Add(List[i].SaveServerToJson());
            }
            return J;
        }
        public void LoadObjectFromJson(JsonArray J)
        {
            List.Clear();
            for (var i = 0; i < J.Count; i++) 
            {
                var S = new Server();
                S.LoadServerFromJson(J[i]);
                List.Add(S);
            }
        }
    }
}
