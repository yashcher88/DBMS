using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Classes.DataRow
{
    public class DataRowColor
    {
        private string _name;
        public string Name { get { return _name; } }
        public DataFieldColor Fields { get; set; }
        public DataRowColor()
        {
            Fields = new DataFieldColor();
        }
        public void SetName(string name)
        {
            _name = name;
        }
    }
}
