using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Enums;

namespace DBMS.Classes
{
    public class UserControlTextBlock : UserControl
    {
        public UserControlTextBlock() {
            ControlType = UserControlType.TextBlock;
            ControlProperty = UserControlProperty.Text;
        }
    }
}
