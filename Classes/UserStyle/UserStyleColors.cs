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
    public class UserStyleColors: INotifyPropertyChanged
    {
        private readonly Dictionary<string, IBrush> _colors = new();

        public event PropertyChangedEventHandler PropertyChanged;

        public UserStyleColors()
        {
            _colors["FormBackground"] = CConvert.FromHex("#cfd6e3");
            _colors["FormForeground"] = CConvert.FromHex("#000000");

            _colors["ControlBackground"] = CConvert.FromHex("#ffffff");
            _colors["ControlBackgroundDisable"] = CConvert.FromHex("#e1e1e1");
            _colors["ControlBackgroundSelected"] = CConvert.FromHex("#b7dbff"); //
            _colors["ControlForeground"] = CConvert.FromHex("#000000");
            _colors["ControlForegroundDisable"] = CConvert.FromHex("#e1e1e1");
            _colors["ControlForegroundSelected"] = CConvert.FromHex("#000000"); //

            _colors["ControlBorder"] = CConvert.FromHex("#7a7a7a");
            _colors["ControlBorderDisable"] = CConvert.FromHex("#adadad");
            
            _colors["ButtonBackground"] = CConvert.FromHex("#e1e1e1");
            _colors["ButtonForeground"] = CConvert.FromHex("#000000");
            _colors["ButtonBorder"] = CConvert.FromHex("#adadad");

            _colors["ButtonBackgroundHover"] = CConvert.FromHex("#e5f1fb");
            _colors["ButtonForegroundHover"] = CConvert.FromHex("#000000");
            _colors["ButtonBorderHover"] = CConvert.FromHex("#0078d7");

            _colors["SplitterColor"] = CConvert.FromHex("#f0f0f0");
        }

        public IBrush this[string key]
        {
            get => _colors.TryGetValue(key, out var v) ? v : null;
            set
            {
                _colors[key] = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Item[]"));
            }
        }
    }
}
