using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Classes
{
    public class DriverPopupElement
    {
        public string Name;
        public DriverScriptLink Caption;
        public List<DriverPopupEvent> Events = new List<DriverPopupEvent>();
        public List<DriverPopupElement> Child = new List<DriverPopupElement>();
    }
}
