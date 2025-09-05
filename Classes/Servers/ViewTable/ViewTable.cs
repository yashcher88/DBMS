using Avalonia.Controls;
using Avalonia.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Classes
{
    public class ViewTable
    {
        public List<string> Columns = new List<string>();
        public List<ViewTableRow> Rows = new List<ViewTableRow>();
        public void FillColumns(List<string> Cols)
        {
            Columns = Cols;
        }
        public void AddRow(List<string> Values)
        {
            Rows.Add(new ViewTableRow(Values));
        }
        public void FillDataGrid(DataGrid D)
        {

            D.AutoGenerateColumns = false;
            D.Columns.Clear();
            D.ItemsSource = Rows;
            for (int i = 0; i < Columns.Count; i++)
            {
                DataGridTextColumn TC = new DataGridTextColumn();
                TC.Header = Columns[i];
                TC.Binding = new Binding($"Fields[{i}]");
                D.Columns.Add(TC);
            }
        }
    }
}
