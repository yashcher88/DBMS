using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Enums
{
    public enum ObjectTreeNodeType
    {
        Unknown,
        Server,
        Database,
        Scheme,
        Table,
        Column,
        HashIndex,
        BTreeIndex,
        Procedure,
        ScalarFunction,
        TableFunction,
        FunctionResult,
        FunctionParameter,
        View
    }
}
