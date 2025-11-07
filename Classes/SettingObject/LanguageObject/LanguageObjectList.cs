using DocumentFormat.OpenXml.Office2010.ExcelAc;
using System.Collections.Generic;
using System.Text.Json.Nodes;

namespace DBMS.Classes
{
    public class LanguageObjectList
    {
        public Dictionary<string,LanguageObject> List = new Dictionary<string, LanguageObject>();
        public void Add(string Name) 
        {
            if (!List.ContainsKey(Name))
            {
                List[Name] = new LanguageObject();
            }
        }
        public void Delete(string Name)
        {
            List.Remove(Name);
        }
        public void Change(string OldName, string NewName)
        {
            LanguageObject M = new LanguageObject();
            if (List.ContainsKey(OldName)) 
            {
                //List[OldName]
                M = List[OldName];
                List.Remove(OldName);
            }
            List[NewName] = M;
        }
        public void LoadFromJson(JsonObject J) 
        {
            List.Clear();
            foreach (var node in J) 
            { 
                var USC = new LanguageObject();
                USC.LoadFromJson(node.Value.AsObject());
                List.Add(node.Key, USC);
            }
        }
        public JsonObject SaveToJson() 
        {
            JsonObject J = new JsonObject();
            foreach (var node in List)
            {
                J[node.Key] = node.Value.SaveToJson();
            }
            return J;
        }
    }
}
