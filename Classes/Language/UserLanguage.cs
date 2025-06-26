using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Classes
{
    public class UserLanguage
    {
        Dictionary<string, UserControlLanguage> Controls = new Dictionary<string, UserControlLanguage>();
    }
}
