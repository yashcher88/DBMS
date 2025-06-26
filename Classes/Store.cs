using DBMS.Classes.Setting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Classes
{
    public class Store
    {
        public List<UserLanguage> Languages = new List<UserLanguage>();
        public int versionPack;

        public Store() {
            Languages.Add(new UserLanguage(Languages.Count, "Русский"));
        }
    }
}
