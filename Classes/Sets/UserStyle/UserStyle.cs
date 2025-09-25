using Avalonia.Media;
using DBMS.Functions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Classes
{
    public class UserStyle
    {
        public UserStyleColors Colors { get; } = new UserStyleColors();
        public UserStyleSizes Sizes { get; } = new UserStyleSizes();
    }
}
