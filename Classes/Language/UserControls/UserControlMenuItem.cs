using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Enums;

namespace DBMS.Classes
{
    public class UserControlMenuItem : UserControl
    {
        public UserControlMenuItem() {
            ControlType = UserControlType.MenuItem;
            ControlProperty = UserControlProperty.Header | UserControlProperty.ToolTip;
        }
    }
}
