using DBMS.Classes.DataRow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Classes
{
    public class DataRowString
    {
        private string _name;
        public string Name { get { return _name; } }
        public DataFieldString Fields { get; set; }
        public DataRowString() 
        {
            Fields = new DataFieldString();
        }
        public void SetName(string name) 
        {
            _name = name;
        }
    }
}
