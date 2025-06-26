using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Enums;

namespace DBMS.Classes
{
    public class UserControlButton : UserControl
    {
        public UserControlButton() {
            ControlType = UserControlType.Button;
            ControlProperty = UserControlProperty.Content | UserControlProperty.ToolTip;
        }
    }
}
