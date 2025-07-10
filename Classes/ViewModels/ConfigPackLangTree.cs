using Avalonia.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Classes
{
    public class ConfigPackLangTreeRow 
    {
        string Name;
    }
    public class ConfigPackLangTree: ObservableCollection<ConfigPackLangTreeRow>
    {
        TreeView TView;
        LanguageObject LObject;
        public ConfigPackLangTree(TreeView V, LanguageObject L)
        { 
            TView = V;
            LObject = L;
            //V.Items = 
        }
    }
}
