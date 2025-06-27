using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Classes
{
    public class Store
    {
        public Dictionary<string,UserLanguage> Languages = new Dictionary<string,UserLanguage>();
        public int versionPack;

        public Store() {
            Languages.Add("Русский", new UserLanguage());
        }
    }
}
