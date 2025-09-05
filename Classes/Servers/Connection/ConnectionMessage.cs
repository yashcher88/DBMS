using DBMS.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Classes
{
    public class ConnectionMessage
    {
        public string Message = "";
        public ConnectionTypeError ErrorType = ConnectionTypeError.Info;
        public int BatchId = 0;
        public int Symbol = 0;
        public int Row = 0;
    }
}
