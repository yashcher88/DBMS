using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                if ((List[i].Host == Host) && (List[i].Port == Port) && (List[i].Login == Login) && (List[i].Driver == driver)) 
                { 
                    return List[i];
                }
            }
            return null;
        }
    }
}
