using Avalonia.Controls;
using Avalonia.Data;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Classes
{
    public abstract class InterfaceSetting
    {
        public DataGrid Grid;
        public ListBox List;
        public ObservableCollection<string> ListRows { get; set; }
        public InterfaceSetting(DataGrid grid, ListBox list)
        {
            Grid = grid;
            List = list;
            ListRows = new ObservableCollection<string>();
        }
        public abstract void ChangeListName(string OldName, string NewName);
        public abstract void FillRows(string LangName, int colI);
        public abstract void ClearGridRows();
        public abstract void FillList();
        public abstract void FillGrid();
        public abstract DataGridColumn GetColumn(string LangName, int colI);

        public void AddColumnToGrid(string LangName)
        {
            var colI = Grid.Columns.Count - 1;
            var TC = GetColumn(LangName, colI);
            TC.CellStyleClasses.Add("UnFirst");
            Grid.Columns.Add(TC);
            FillRows(LangName, colI);
            Grid.InvalidateVisual();
        }
        public void BeforeChangeItemName(int Index, string OldName, string NewName)
        {
            if (OldName == null || OldName.Length == 0)
            {
                //Добавление нового
                ChangeListName(OldName, NewName);
                AddColumnToGrid(NewName);
            }
            else
            {
                ChangeListName(OldName, NewName);
                Grid.Columns[Index + 1].Header = NewName;
            }
        }
        public void EditItemList(int item)
        {
            string s = List.Items[item].ToString();
            var B = new TextBox();
            B.KeyDown += (sender, e) => {
                if (e.Key == Avalonia.Input.Key.Enter)
                {
                    List.Items[item] = B.Text;
                }
                else if (e.Key == Avalonia.Input.Key.Escape)
                {
                    List.Items[item] = s;
                }
            };
            B.LostFocus += (sender, e) =>
            {
                BeforeChangeItemName(item, s, B.Text);
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
                Binding = new Binding($"Name"),
                IsReadOnly = true,
            };
            TC.CellStyleClasses.Add("UnFirst");
            Grid.Columns.Add(TC);
            //Зачищаем объекты связи
            ListRows.Clear();
            List.Items.Clear();
            ClearGridRows();
        }
        public void AddToList(string ColumnName)
        {
            ListRows.Add(ColumnName);
            List.Items.Add(ColumnName);
        }
        public void AddItemToList(string ColumnName)
        {
            AddToList(ColumnName);
            AddColumnToGrid(ColumnName);
        }
        public void Refresh()
        {
            Clear();
            FillList();
        }
        public void AddItem()
        {
            var i = ListRows.Count;
            AddToList("");
            EditItemList(i);
        }
        public void RenameItem()
        {
            if (List.SelectedIndex >= 0)
            {
                EditItemList(List.SelectedIndex);
            }
        }
        public void RemoveItem()
        {
            if (List.SelectedIndex == -1)
                return;
            ListRows.RemoveAt(List.SelectedIndex);
            Grid.Columns.RemoveAt(List.SelectedIndex + 1);
            List.Items.RemoveAt(List.SelectedIndex);
        }
    }
}
