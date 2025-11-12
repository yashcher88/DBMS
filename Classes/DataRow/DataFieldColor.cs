using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Media;
namespace DBMS.Classes.DataRow
{
    public class DataFieldColor
    {
        List<Color> _list = new List<Color>();

        public event PropertyChangedEventHandler PropertyChanged;
        public Color this[int key]
        {
            get
            {
                if (key >= 0 && key < _list.Count)
                {
                    return _list[key];
                }
                else
                {
                    return Color.Parse("#ffffff");
                }
            }
            set
            {
                if (key == _list.Count)
                {
                    _list.Add(value);
                }
                else
                {
                    _list[key] = value;
                }
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Item[]"));
            }
        }
        public int Add(Color value)
        {
            var i = _list.Count;
            _list.Add(value);
            return i;
        }
    }
}
