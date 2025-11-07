using Avalonia.Controls;
using Avalonia.Data;
using DocumentFormat.OpenXml.Drawing;
using DynamicData;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Classes
{
    public class InterfaceSetting
    {
        DataGrid Grid;
        ListBox List;
        LanguageObjectList LangList;
        public ObservableCollection<string> ListRows { get; set; }
        public ObservableCollection<DataRowString> GridRows { get; set; }
        public InterfaceSetting(DataGrid grid, ListBox list, LanguageObjectList lang_1ist) 
        { 
            Grid = grid;
            List = list;
            LangList = lang_1ist;
            ListRows = new ObservableCollection<string>();
            GridRows = new ObservableCollection<DataRowString>();

            Grid.ItemsSource = GridRows;
            List.ItemsSource = ListRows;
        }
        public void BeforeChangeItemName(string OldName, string NewName) 
        {
            if (OldName == null || OldName.Length == 0) 
            {
                //Добавление нового
                LangList.Change(OldName, NewName);
                AddColumnToGrid(NewName);
            }
            else
            {
                LangList.Change(OldName, NewName);
            }
            
        }
        public void EditItemList(int item)
        {
            string s = List.Items[item].ToString();
            var B = new TextBox();
            B.KeyDown += (sender, e) => {
                if (e.Key == Avalonia.Input.Key.Enter)
                {
                    BeforeChangeItemName(B.Text, s);
                    List.Items[item] = B.Text;
                }
            };
            B.LostFocus += (sender, e) =>
            {
                BeforeChangeItemName(B.Text, s);
                List.Items[item] = B.Text;
            };
            B.Text = s;
            List.Items[item] = B;
            B.AttachedToVisualTree += (sender, e) =>
            {
                B.Focus();
                B.CaretIndex = B.Text?.Length ?? 0;
            };
        }
        public void Clear() 
        {
            //Зачищаем столбцы таблицы
            Grid.Columns.Clear();
            //Добавляем первую колонку по умолчанию
            var TC = new DataGridTextColumn
            {
                Header = Program.store.Sets.Language["Property"],
                Binding = new Binding($"Name")
            };
            TC.CellStyleClasses.Add("UnFirst");
            Grid.Columns.Add(TC);
            //Зачищаем объекты связи
            ListRows.Clear();
            GridRows.Clear();
        }
        public void AddItemToList(string ColumnName) 
        {
            ListRows.Add(ColumnName);
            AddColumnToGrid(ColumnName);
        }
        public void FillList()
        {
            foreach (var item in LangList.List) 
            {
                AddItemToList(item.Key);
            }
        }
        public void AddColumnToGrid(string LangName) 
        {
            var colI = Grid.Columns.Count - 1;
            var TC = new DataGridTextColumn
            {
                Header = LangName,
                Binding = new Binding($"Fields[{colI}]")
            };
            TC.CellStyleClasses.Add("UnFirst");
            Grid.Columns.Add(TC);
            var i = 0;
            foreach (var node in Program.store.Sets.Language._text) 
            {
                DataRowString D;
                if (i >= GridRows.Count)
                {
                    D = new DataRowString();
                    D.SetName(node.Key);
                }
                else 
                {
                    D = GridRows[i];
                }
                D.Fields[colI] = node.Value;
                i++;
            }
        }
        public void FillGrid()
        {
            foreach (var node in LangList.List) 
            {
                AddColumnToGrid(node.Key);
            }
        }
        public void Refresh()
        {
            Clear();
            FillList();
            FillGrid();
        }
        public void AddItem()
        {
            var i = List.Items.Add("");
            EditItemList(i);
        }
        public void RenameItem()
        {

        }
        public void RemoveItem()
        {
            //if (List.SelectedIndex == -1) return;

        }
    }
}
