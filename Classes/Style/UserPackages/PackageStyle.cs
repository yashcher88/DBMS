using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Classes.Style.UserPackages
{
    public class PackageStyle
    {
        public int Id;
        public string Code;
        public List<PackageLanguage> PackageLanguages = new List<PackageLanguage>();
    }
}
