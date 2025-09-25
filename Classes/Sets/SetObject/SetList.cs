using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Classes.Sets.SetObject
{
    public class SetList
    {
        List<string> List = new List<string>();
        int _vIndex;
        string _vValue;
        public string Value { get { return _vValue;} set { ValueSet(value); } }
        public int ValueIndex { get { return _vIndex; }}
        public SetList() 
        {
            List.Add("Default");
            Value = "Default";
            _vIndex = 0;
        }
        public void ValueSet(string _v) 
        {
            var i = List.IndexOf(_v);
            if (i >= 0) 
            {
                _vIndex = i;
                _vValue = _v;
            }
        }
    }
}
