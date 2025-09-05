using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Classes
{
    public class ViewTableRow
    {
        public List<string> Fields { get; set; }
        public ViewTableRow(List<string> L)
        {
            Fields = L;
        }
    }
}
