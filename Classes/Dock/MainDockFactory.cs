using Dock.Model.Avalonia;
using Dock.Avalonia.Controls;
using Dock.Model.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Classes
{
    public class MainDockFactory : Factory
    {
        public override void InitLayout(IDockable layout)
        {

            HostWindowLocator = new Dictionary<string, Func<IHostWindow>>
            {
                [nameof(IDockWindow)] = () => new HostWindow()
            };

            base.InitLayout(layout);
        }
    }
}
