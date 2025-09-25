using Avalonia.Controls;

namespace DBMS.Classes
{
    public class BaseUserControl : UserControl
    {
        public Store store;
        public BaseUserControl()
        {
            store = Program.store;
        }
    }
}
