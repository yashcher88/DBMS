using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Classes.DataRow
{
    public class DataRowColor
    {
        public string Name { get; }
        public List<object> Fields { get; set; }
        public DataRowColor()
        {
            Fields = new List<object>();
        }
    }
}
