using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Enums;

namespace DBMS.Classes.Language.Old.UserControls
{
    public class UserControlWindow: UserControl
    {
        public UserControlWindow() {
            ControlType = UserControlType.Window;
            ControlProperty = UserControlProperty.Title;
        }
    }
}
