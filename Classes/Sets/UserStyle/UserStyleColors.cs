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
            /* Цвета Формы */
            _colors["FormBackground"] = CConvert.FromHex("#cfd6e3");
            _colors["FormForeground"] = CConvert.FromHex("#000000");

            /* Цвета Панелей */
            _colors["PanelBackground"] = CConvert.FromHex("#cfd6e3");
            _colors["PanelForeground"] = CConvert.FromHex("#000000");
            _colors["PanelBorder"] = CConvert.FromHex("#000000");

            /* Цвета Пунктов меню */
            _colors["MenuHeaderNormalBgColor"] = CConvert.FromHex("#e1e1e1");
            _colors["MenuHeaderNormalTextColor"] = CConvert.FromHex("#000000");
            _colors["MenuHeaderNormalBorderColor"] = CConvert.FromHex("#adadad");
            _colors["MenuHeaderDisableBgColor"] = CConvert.FromHex("#e1e1e1");
            _colors["MenuHeaderDisableTextColor"] = CConvert.FromHex("#000000");
            _colors["MenuHeaderDisableBorderColor"] = CConvert.FromHex("#adadad");
            _colors["MenuHeaderFocusBgColor"] = CConvert.FromHex("#e1e1e1");
            _colors["MenuHeaderFocusTextColor"] = CConvert.FromHex("#000000");
            _colors["MenuHeaderFocusBorderColor"] = CConvert.FromHex("#adadad");
            _colors["MenuPanelBgColor"] = CConvert.FromHex("#e1e1e1");
            _colors["MenuPanelTextColor"] = CConvert.FromHex("#000000");
            _colors["MenuPanelBorderColor"] = CConvert.FromHex("#adadad");
            _colors["MenuItemNormalBgColor"] = CConvert.FromHex("#e1e1e1");
            _colors["MenuItemNormalTextColor"] = CConvert.FromHex("#000000");
            _colors["MenuItemNormalBorderColor"] = CConvert.FromHex("#adadad");
            _colors["MenuItemDisableBgColor"] = CConvert.FromHex("#e1e1e1");
            _colors["MenuItemDisableTextColor"] = CConvert.FromHex("#000000");
            _colors["MenuItemDisableBorderColor"] = CConvert.FromHex("#adadad");
            _colors["MenuItemFocusBgColor"] = CConvert.FromHex("#e1e1e1");
            _colors["MenuItemFocusTextColor"] = CConvert.FromHex("#000000");
            _colors["MenuItemFocusBorderColor"] = CConvert.FromHex("#adadad");

            /* Цвета Таблиц */
            _colors["GridHeaderNormalBgColor"] = CConvert.FromHex("#e1e1e1");
            _colors["GridHeaderNormalTextColor"] = CConvert.FromHex("#000000");
            _colors["GridHeaderNormalBorderColor"] = CConvert.FromHex("#adadad");
            _colors["GridHeaderFocusBgColor"] = CConvert.FromHex("#e1e1e1");
            _colors["GridHeaderFocusTextColor"] = CConvert.FromHex("#000000");
            _colors["GridHeaderFocusBorderColor"] = CConvert.FromHex("#adadad");
            _colors["GridHeaderHoverBgColor"] = CConvert.FromHex("#e1e1e1");
            _colors["GridHeaderHoverTextColor"] = CConvert.FromHex("#000000");
            _colors["GridHeaderHoverBorderColor"] = CConvert.FromHex("#adadad");
            _colors["GridHeaderClickedBgColor"] = CConvert.FromHex("#e1e1e1");
            _colors["GridHeaderClickedTextColor"] = CConvert.FromHex("#000000");
            _colors["GridHeaderClickedBorderColor"] = CConvert.FromHex("#adadad");

            _colors["GridCellNormalBgColor1"] = CConvert.FromHex("#e1e1e1");
            _colors["GridCellNormalTextColor1"] = CConvert.FromHex("#000000");
            _colors["GridCellNormalBorderColor1"] = CConvert.FromHex("#adadad");
            _colors["GridCellFocusBgColor1"] = CConvert.FromHex("#e1e1e1");
            _colors["GridCellFocusTextColor1"] = CConvert.FromHex("#000000");
            _colors["GridCellFocusBorderColor1"] = CConvert.FromHex("#adadad");
            _colors["GridCellNullBgColor1"] = CConvert.FromHex("#e1e1e1");
            _colors["GridCellNullTextColor1"] = CConvert.FromHex("#000000");
            _colors["GridCellNullBorderColor1"] = CConvert.FromHex("#adadad");

            _colors["GridCellNormalBgColor2"] = CConvert.FromHex("#e1e1e1");
            _colors["GridCellNormalTextColor2"] = CConvert.FromHex("#000000");
            _colors["GridCellNormalBorderColor2"] = CConvert.FromHex("#adadad");
            _colors["GridCellFocusBgColor2"] = CConvert.FromHex("#e1e1e1");
            _colors["GridCellFocusTextColor2"] = CConvert.FromHex("#000000");
            _colors["GridCellFocusBorderColor2"] = CConvert.FromHex("#adadad");
            _colors["GridCellNullBgColor2"] = CConvert.FromHex("#e1e1e1");
            _colors["GridCellNullTextColor2"] = CConvert.FromHex("#000000");
            _colors["GridCellNullBorderColor2"] = CConvert.FromHex("#adadad");

            /* Цвета Текстового редактора */
            _colors["ControlNormalBgColor"] = CConvert.FromHex("#e1e1e1");
            _colors["ControlNormalTextColor"] = CConvert.FromHex("#000000");
            _colors["ControlNormalBorderColor"] = CConvert.FromHex("#adadad");
            _colors["ControlDisableBgColor"] = CConvert.FromHex("#e1e1e1");
            _colors["ControlDisableTextColor"] = CConvert.FromHex("#000000");
            _colors["ControlDisableBorderColor"] = CConvert.FromHex("#adadad");
            _colors["ControlFocusBgColor"] = CConvert.FromHex("#e1e1e1");
            _colors["ControlFocusTextColor"] = CConvert.FromHex("#000000");
            _colors["ControlFocusBorderColor"] = CConvert.FromHex("#adadad");
            _colors["ControlSelectionBgColor"] = CConvert.FromHex("#e1e1e1");
            _colors["ControlSelectionTextColor"] = CConvert.FromHex("#000000");

            /* Цвета элементов ввода */
            _colors["ControlNormalBgColor"] = CConvert.FromHex("#e1e1e1");
            _colors["ControlNormalTextColor"] = CConvert.FromHex("#000000");
            _colors["ControlNormalBorderColor"] = CConvert.FromHex("#adadad");
            _colors["ControlDisableBgColor"] = CConvert.FromHex("#e1e1e1");
            _colors["ControlDisableTextColor"] = CConvert.FromHex("#000000");
            _colors["ControlDisableBorderColor"] = CConvert.FromHex("#adadad");
            _colors["ControlFocusBgColor"] = CConvert.FromHex("#e1e1e1");
            _colors["ControlFocusTextColor"] = CConvert.FromHex("#000000");
            _colors["ControlFocusBorderColor"] = CConvert.FromHex("#adadad");
            _colors["ControlSelectionBgColor"] = CConvert.FromHex("#e1e1e1");
            _colors["ControlSelectionTextColor"] = CConvert.FromHex("#000000");

            /* Цвета кнопок */
            _colors["ButtonNormalBgColor"] = CConvert.FromHex("#e1e1e1");
            _colors["ButtonNormalTextColor"] = CConvert.FromHex("#000000");
            _colors["ButtonNormalBorderColor"] = CConvert.FromHex("#adadad");
            _colors["ButtonDisableBgColor"] = CConvert.FromHex("#e1e1e1");
            _colors["ButtonDisableTextColor"] = CConvert.FromHex("#000000");
            _colors["ButtonDisableBorderColor"] = CConvert.FromHex("#adadad");
            _colors["ButtonHoverBgColor"] = CConvert.FromHex("#e1e1e1");
            _colors["ButtonHoverTextColor"] = CConvert.FromHex("#000000");
            _colors["ButtonHoverBorderColor"] = CConvert.FromHex("#adadad");
            _colors["ButtonClickedBgColor"] = CConvert.FromHex("#e1e1e1");
            _colors["ButtonClickedTextColor"] = CConvert.FromHex("#000000");
            _colors["ButtonClickedBorderColor"] = CConvert.FromHex("#adadad");

            /* Цвета главной кнопки на форме */
            _colors["MainButtonNormalBgColor"] = CConvert.FromHex("#e1e1e1");
            _colors["MainButtonNormalTextColor"] = CConvert.FromHex("#000000");
            _colors["MainButtonNormalBorderColor"] = CConvert.FromHex("#adadad");
            _colors["MainButtonDisableBgColor"] = CConvert.FromHex("#e1e1e1");
            _colors["MainButtonDisableTextColor"] = CConvert.FromHex("#000000");
            _colors["MainButtonDisableBorderColor"] = CConvert.FromHex("#adadad");
            _colors["MainButtonHoverBgColor"] = CConvert.FromHex("#e1e1e1");
            _colors["MainButtonHoverTextColor"] = CConvert.FromHex("#000000");
            _colors["MainButtonHoverBorderColor"] = CConvert.FromHex("#adadad");
            _colors["MainButtonClickedBgColor"] = CConvert.FromHex("#e1e1e1");
            _colors["MainButtonClickedTextColor"] = CConvert.FromHex("#000000");
            _colors["MainButtonClickedBorderColor"] = CConvert.FromHex("#adadad");

            /*Цвет Splitter*/
            _colors["SplitterNormalColor"] = CConvert.FromHex("#f0f0f0");
            _colors["SplitterActiveColor"] = CConvert.FromHex("#f0f0f0");
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
