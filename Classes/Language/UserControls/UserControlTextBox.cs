using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Enums;

namespace DBMS.Classes
{
    public class UserControlTextBox : UserControl
    {
        public UserControlTextBox() {
            ControlType = UserControlType.TextBox;
            ControlProperty = UserControlProperty.Text | UserControlProperty.WaterMark;
        }
    }
}
