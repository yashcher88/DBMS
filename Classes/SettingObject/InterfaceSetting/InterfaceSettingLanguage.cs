using Avalonia.Controls;
using Avalonia.Data;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Collections.ObjectModel;

namespace DBMS.Classes
{
    public class InterfaceSettingLanguage : InterfaceSetting
    {
        LanguageObjectList LangList;
        public ObservableCollection<DataRowString> GridRows { get; set; }
        public InterfaceSettingLanguage(DataGrid grid, ListBox list, LanguageObjectList lang_1ist) 
            : base(grid, list)
        { 
            LangList = lang_1ist;
            GridRows = new ObservableCollection<DataRowString>();
            Grid.ItemsSource = GridRows;
        }
        public override void ChangeListName(string OldName, string NewName) 
        {
            LangList.Change(OldName, NewName);
        }
        public override void FillRows(string LangName, int colI)
        {
            var i = 0;
            foreach (var node in Program.store.Sets.LanguageList.List[LangName]._text)
            {
                DataRowString D;
                if (i >= GridRows.Count)
                {
                    D = new DataRowString();
                    GridRows.Add(D);
                    D.SetName(node.Key);
                }
                else
                {
                    D = GridRows[i];
                }
                D.Fields[colI] = node.Value;
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
            foreach (var item in LangList.List)
            {
                AddItemToList(item.Key);
            }
        }
        public override void FillGrid()
        {
            foreach (var node in LangList.List)
            {
                AddColumnToGrid(node.Key);
            }
        }
        public override DataGridColumn GetColumn(string LangName, int colI) { 
            return new DataGridTextColumn
            {
                Header = LangName,
                Binding = new Binding($"Fields[{colI}]")
            };
        }
        public void ChangeCell(DataGridCellEditEndedEventArgs e) 
        {
            DataRowString D = e.Row?.DataContext as DataRowString;
            if (D != null) 
            {
                string LangName = e.Column.Header.ToString();
                string ParamName = D.Name;
                string NewValue = D.Fields[e.Column.DisplayIndex - 1];
                Program.store.Sets.LanguageList.List[LangName][ParamName] = NewValue;
            }
            
        }
    }
}
