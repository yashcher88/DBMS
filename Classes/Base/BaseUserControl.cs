using Avalonia.Controls;

namespace DBMS.Classes
{
    public class BaseUserControl : UserControl
    {
        public Store store { get { return Program.store; } }
    }
}
