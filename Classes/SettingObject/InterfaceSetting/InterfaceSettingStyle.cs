using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Avalonia.Data;
using Avalonia.Media;
using DBMS.Classes.DataRow;
using DynamicData;
using System.Collections.ObjectModel;

namespace DBMS.Classes
{
    public class InterfaceSettingStyle : InterfaceSetting
    {
        StyleObjectList StyleList;
        public ObservableCollection<DataRowColor> GridRows { get; set; }
        public InterfaceSettingStyle(DataGrid grid, ListBox list, StyleObjectList style_1ist) 
            : base(grid, list)
        { 
            StyleList = style_1ist;
            GridRows = new ObservableCollection<DataRowColor>();
            Grid.ItemsSource = GridRows;
        }
        public override void ChangeListName(string OldName, string NewName)
        {
            StyleList.Change(OldName, NewName);
        }
        public override void FillRows(string LangName, int colI)
        {
            var i = 0;
            foreach (var node in Program.store.Sets.StyleList.List[LangName]._colors)
            {
                DataRowColor D;
                if (i >= GridRows.Count)
                {
                    D = new DataRowColor();
                    GridRows.Add(D);
                    D.SetName(node.Key);
                }
                else
                {
                    D = GridRows[i];
                }
                D.Fields[colI] = (node.Value as ISolidColorBrush).Color;
                GridRows[i] = D;
                i++;
            }
        }
        public override void ClearGridRows()
        {
            GridRows.Clear();
        }
        public override void FillList()
        {
            foreach (var item in StyleList.List)
            {
                AddItemToList(item.Key);
            }
        }
        public override void FillGrid()
        {
            foreach (var node in StyleList.List)
            {
                AddColumnToGrid(node.Key);
            }
        }
        public override DataGridColumn GetColumn(string LangName, int colI) 
        {
            return new DataGridTemplateColumn
            {
                Header = LangName,
                MinWidth = 100,
                MaxWidth = 100,
                CanUserResize = false,
                // шаблон отображения (ячейка в режиме просмотра)
                CellTemplate = new FuncDataTemplate<object>((item, _) =>
                {
                    var border = new Border
                    {
                        Width = 100,
                        Height = 20,
                        BorderBrush = Brushes.Gray/*,
                        BorderThickness = new Thickness(1)*/
                    };

                    // Привязываем цвет к Background
                    border.Bind(
                        Border.BackgroundProperty,
                        new Binding($"Fields[{colI}]") { Converter = new ColorToBrushConverter() }
                    );

                    return border;
                }),

                // шаблон редактирования (при двойном клике)
                CellEditingTemplate = new FuncDataTemplate<object>((item, _) =>
                {
                    var picker = new ColorPicker();
                    picker.Classes.Add("Std");
                    picker.Width = 100;
                    picker.Bind(ColorView.ColorProperty, new Binding($"Fields[{colI}]") { Mode = BindingMode.TwoWay });
                    return picker;
                })
            };
        }
        public void ChangeCell(DataGridCellEditEndedEventArgs e) 
        {
            DataRowColor D = e.Row?.DataContext as DataRowColor;
            if (D != null) 
            {
                string LangName = e.Column.Header.ToString();
                string ParamName = D.Name;
                Color NewValue = D.Fields[e.Column.DisplayIndex - 1];
                Program.store.Sets.StyleList.List[LangName][ParamName] = new SolidColorBrush(NewValue);
            }
            
        }
    }
}
