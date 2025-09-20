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
            var R = new ViewTableRow(Values);
            R.Index = Rows.Count + 1;
            Rows.Add(R);
        }
        public void FillDataGrid(DataGrid D)
        {

            D.AutoGenerateColumns = false;
            D.Columns.Clear();
            D.ItemsSource = Rows;
            DataGridTextColumn TC1 = new DataGridTextColumn();
            TC1.Header = "";
            TC1.Binding = new Binding("Index");
            D.Columns.Add(TC1);

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
