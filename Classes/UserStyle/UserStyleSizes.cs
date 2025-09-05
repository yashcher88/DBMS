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
    public class UserStyleSizes : INotifyPropertyChanged
    {
        private readonly Dictionary<string, int> _colors = new();

        public event PropertyChangedEventHandler PropertyChanged;

        public UserStyleSizes()
        {
            _colors["LabelFontSize"] = 12;
            _colors["Border"] = 1;
        }

        public int this[string key]
        {
            get => _colors.TryGetValue(key, out var v) ? v : 1;
            set
            {
                _colors[key] = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Item[]"));
            }
        }
    }
}
