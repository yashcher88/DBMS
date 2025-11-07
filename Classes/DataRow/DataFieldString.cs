using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Classes.DataRow
{
    public class DataFieldString : INotifyPropertyChanged
    {
        List<string> _list = new List<string>();

        public event PropertyChangedEventHandler PropertyChanged;
        public string this[int key]
        {
            get
            {
                if (key >= 0 && key < _list.Count)
                {
                    return _list[key];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                _list[key] = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Item[]"));
            }
        }
        public int Add(string value) 
        { 
            var i = _list.Count;
            _list.Add(value);
            return i;
        }
    }
}
