using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS.Enums;

namespace DBMS.Classes.Language.Old.UserControls
{
    public class UserControlTabItem : UserControl
    {
        public UserControlTabItem() {
            ControlType = UserControlType.TabItem;
            ControlProperty = UserControlProperty.Header | UserControlProperty.ToolTip;
        }
    }
}
