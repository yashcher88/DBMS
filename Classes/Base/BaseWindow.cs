using Avalonia.Controls;

namespace DBMS.Classes
{
    public class BaseWindow : Window
    {
        public Store store;
        public BaseWindow()
        {
            store = Program.store;
        }
    }
}
