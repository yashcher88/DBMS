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
        public string Name;
        public int Id;

        public UserLanguage(int id, string name) { 
            Id = id;
            Name = name;
        }
    }
}
