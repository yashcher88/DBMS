using Avalonia;
using Avalonia.Media;
using DBMS.Functions;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json.Nodes;

namespace DBMS.Classes
{
    public class StyleObject : INotifyPropertyChanged
    {
        public readonly Dictionary<string, IBrush> _colors = new();

        public event PropertyChangedEventHandler PropertyChanged;
        public StyleObject()
        {
            var cols = new Dictionary<string, IBrush>();

            /*
            Внимание! После добавления нового цвета необходимо добавить его в App.axaml
             */

            /* Цвета Формы */
            _colors["FormBackground"] = CConvert.HexToColor("#cfd6e3");
            _colors["FormForeground"] = CConvert.HexToColor("#000000");

            /* Цвета Панелей */
            _colors["PanelBackground"] = CConvert.HexToColor("#cfd6e3");
            _colors["PanelForeground"] = CConvert.HexToColor("#000000");
            _colors["PanelBorder"] = CConvert.HexToColor("#000000");

            /* Цвета Пунктов меню */
            _colors["MenuHeaderNormalBgColor"] = CConvert.HexToColor("#e1e1e1");
            _colors["MenuHeaderNormalTextColor"] = CConvert.HexToColor("#000000");
            _colors["MenuHeaderNormalBorderColor"] = CConvert.HexToColor("#adadad");
            _colors["MenuHeaderDisableBgColor"] = CConvert.HexToColor("#e1e1e1");
            _colors["MenuHeaderDisableTextColor"] = CConvert.HexToColor("#000000");
            _colors["MenuHeaderDisableBorderColor"] = CConvert.HexToColor("#adadad");
            _colors["MenuHeaderFocusBgColor"] = CConvert.HexToColor("#e1e1e1");
            _colors["MenuHeaderFocusTextColor"] = CConvert.HexToColor("#000000");
            _colors["MenuHeaderFocusBorderColor"] = CConvert.HexToColor("#adadad");
            _colors["MenuPanelBgColor"] = CConvert.HexToColor("#e1e1e1");
            _colors["MenuPanelTextColor"] = CConvert.HexToColor("#000000");
            _colors["MenuPanelBorderColor"] = CConvert.HexToColor("#adadad");
            _colors["MenuItemNormalBgColor"] = CConvert.HexToColor("#e1e1e1");
            _colors["MenuItemNormalTextColor"] = CConvert.HexToColor("#000000");
            _colors["MenuItemNormalBorderColor"] = CConvert.HexToColor("#adadad");
            _colors["MenuItemDisableBgColor"] = CConvert.HexToColor("#e1e1e1");
            _colors["MenuItemDisableTextColor"] = CConvert.HexToColor("#000000");
            _colors["MenuItemDisableBorderColor"] = CConvert.HexToColor("#adadad");
            _colors["MenuItemFocusBgColor"] = CConvert.HexToColor("#e1e1e1");
            _colors["MenuItemFocusTextColor"] = CConvert.HexToColor("#000000");
            _colors["MenuItemFocusBorderColor"] = CConvert.HexToColor("#adadad");

            /* Цвета Таблиц */
            _colors["GridHeaderNormalBgColor"] = CConvert.HexToColor("#e1e1e1");
            _colors["GridHeaderNormalTextColor"] = CConvert.HexToColor("#000000");
            _colors["GridHeaderNormalBorderColor"] = CConvert.HexToColor("#adadad");
            _colors["GridHeaderFocusBgColor"] = CConvert.HexToColor("#e1e1e1");
            _colors["GridHeaderFocusTextColor"] = CConvert.HexToColor("#000000");
            _colors["GridHeaderFocusBorderColor"] = CConvert.HexToColor("#adadad");
            _colors["GridHeaderHoverBgColor"] = CConvert.HexToColor("#e1e1e1");
            _colors["GridHeaderHoverTextColor"] = CConvert.HexToColor("#000000");
            _colors["GridHeaderHoverBorderColor"] = CConvert.HexToColor("#adadad");
            _colors["GridHeaderClickedBgColor"] = CConvert.HexToColor("#e1e1e1");
            _colors["GridHeaderClickedTextColor"] = CConvert.HexToColor("#000000");
            _colors["GridHeaderClickedBorderColor"] = CConvert.HexToColor("#adadad");

            _colors["GridCellNormalBgColor1"] = CConvert.HexToColor("#e1e1e1");
            _colors["GridCellNormalTextColor1"] = CConvert.HexToColor("#000000");
            _colors["GridCellNormalBorderColor1"] = CConvert.HexToColor("#adadad");
            _colors["GridCellFocusBgColor1"] = CConvert.HexToColor("#e1e1e1");
            _colors["GridCellFocusTextColor1"] = CConvert.HexToColor("#000000");
            _colors["GridCellFocusBorderColor1"] = CConvert.HexToColor("#adadad");
            _colors["GridCellNullBgColor1"] = CConvert.HexToColor("#e1e1e1");
            _colors["GridCellNullTextColor1"] = CConvert.HexToColor("#000000");
            _colors["GridCellNullBorderColor1"] = CConvert.HexToColor("#adadad");

            _colors["GridCellNormalBgColor2"] = CConvert.HexToColor("#e1e1e1");
            _colors["GridCellNormalTextColor2"] = CConvert.HexToColor("#000000");
            _colors["GridCellNormalBorderColor2"] = CConvert.HexToColor("#adadad");
            _colors["GridCellFocusBgColor2"] = CConvert.HexToColor("#e1e1e1");
            _colors["GridCellFocusTextColor2"] = CConvert.HexToColor("#000000");
            _colors["GridCellFocusBorderColor2"] = CConvert.HexToColor("#adadad");
            _colors["GridCellNullBgColor2"] = CConvert.HexToColor("#e1e1e1");
            _colors["GridCellNullTextColor2"] = CConvert.HexToColor("#000000");
            _colors["GridCellNullBorderColor2"] = CConvert.HexToColor("#adadad");

            /* Цвета Текстового редактора */
            _colors["ControlNormalBgColor"] = CConvert.HexToColor("#e1e1e1");
            _colors["ControlNormalTextColor"] = CConvert.HexToColor("#000000");
            _colors["ControlNormalBorderColor"] = CConvert.HexToColor("#adadad");
            _colors["ControlDisableBgColor"] = CConvert.HexToColor("#e1e1e1");
            _colors["ControlDisableTextColor"] = CConvert.HexToColor("#000000");
            _colors["ControlDisableBorderColor"] = CConvert.HexToColor("#adadad");
            _colors["ControlFocusBgColor"] = CConvert.HexToColor("#e1e1e1");
            _colors["ControlFocusTextColor"] = CConvert.HexToColor("#000000");
            _colors["ControlFocusBorderColor"] = CConvert.HexToColor("#adadad");
            _colors["ControlSelectionBgColor"] = CConvert.HexToColor("#e1e1e1");
            _colors["ControlSelectionTextColor"] = CConvert.HexToColor("#000000");

            /* Цвета элементов ввода */
            _colors["ControlNormalBgColor"] = CConvert.HexToColor("#e1e1e1");
            _colors["ControlNormalTextColor"] = CConvert.HexToColor("#000000");
            _colors["ControlNormalBorderColor"] = CConvert.HexToColor("#adadad");
            _colors["ControlDisableBgColor"] = CConvert.HexToColor("#e1e1e1");
            _colors["ControlDisableTextColor"] = CConvert.HexToColor("#000000");
            _colors["ControlDisableBorderColor"] = CConvert.HexToColor("#adadad");
            _colors["ControlFocusBgColor"] = CConvert.HexToColor("#e1e1e1");
            _colors["ControlFocusTextColor"] = CConvert.HexToColor("#000000");
            _colors["ControlFocusBorderColor"] = CConvert.HexToColor("#adadad");
            _colors["ControlSelectionBgColor"] = CConvert.HexToColor("#e1e1e1");
            _colors["ControlSelectionTextColor"] = CConvert.HexToColor("#000000");

            /* Цвета кнопок */
            _colors["ButtonNormalBgColor"] = CConvert.HexToColor("#e1e1e1");
            _colors["ButtonNormalTextColor"] = CConvert.HexToColor("#000000");
            _colors["ButtonNormalBorderColor"] = CConvert.HexToColor("#adadad");
            _colors["ButtonDisableBgColor"] = CConvert.HexToColor("#e1e1e1");
            _colors["ButtonDisableTextColor"] = CConvert.HexToColor("#000000");
            _colors["ButtonDisableBorderColor"] = CConvert.HexToColor("#adadad");
            _colors["ButtonHoverBgColor"] = CConvert.HexToColor("#e1e1e1");
            _colors["ButtonHoverTextColor"] = CConvert.HexToColor("#000000");
            _colors["ButtonHoverBorderColor"] = CConvert.HexToColor("#adadad");
            _colors["ButtonClickedBgColor"] = CConvert.HexToColor("#e1e1e1");
            _colors["ButtonClickedTextColor"] = CConvert.HexToColor("#000000");
            _colors["ButtonClickedBorderColor"] = CConvert.HexToColor("#adadad");

            /* Цвета главной кнопки на форме */
            _colors["MainButtonNormalBgColor"] = CConvert.HexToColor("#e1e1e1");
            _colors["MainButtonNormalTextColor"] = CConvert.HexToColor("#000000");
            _colors["MainButtonNormalBorderColor"] = CConvert.HexToColor("#adadad");
            _colors["MainButtonDisableBgColor"] = CConvert.HexToColor("#e1e1e1");
            _colors["MainButtonDisableTextColor"] = CConvert.HexToColor("#000000");
            _colors["MainButtonDisableBorderColor"] = CConvert.HexToColor("#adadad");
            _colors["MainButtonHoverBgColor"] = CConvert.HexToColor("#e1e1e1");
            _colors["MainButtonHoverTextColor"] = CConvert.HexToColor("#000000");
            _colors["MainButtonHoverBorderColor"] = CConvert.HexToColor("#adadad");
            _colors["MainButtonClickedBgColor"] = CConvert.HexToColor("#e1e1e1");
            _colors["MainButtonClickedTextColor"] = CConvert.HexToColor("#000000");
            _colors["MainButtonClickedBorderColor"] = CConvert.HexToColor("#adadad");

            /*Цвет Splitter*/
            _colors["SplitterNormalColor"] = CConvert.HexToColor("#f0f0f0");
            _colors["SplitterActiveColor"] = CConvert.HexToColor("#f0f0f0");
        }
        public void ApplyStyleSettings() 
        {
            foreach (var color in _colors)
            {
                App.Instance.Resources[color.Key] = color.Value;
            }
        }
        public void ApplyFromStyleObject(StyleObject C)
        {
            foreach (var color in C._colors)
            {
                _colors[color.Key] = color.Value;
            }
            ApplyStyleSettings();
        }
        public void LoadFromJson(JsonObject J)
        {
            foreach (var node in J)
            {
                _colors[node.Key] = CConvert.HexToColor(node.Value.ToString());
            }
        }
        public JsonObject SaveToJson() 
        { 
            JsonObject J = new JsonObject();
            foreach (var node in _colors)
            {
                J[node.Key] = node.Value.ToString();
            }
            return J;
        }

        public IBrush this[string key]
        {
            get
            {
                var B = _colors.TryGetValue(key, out var v);
                if (B)
                {
                    return v;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                _colors[key] = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Item[]"));
            }
        }
    }
}
