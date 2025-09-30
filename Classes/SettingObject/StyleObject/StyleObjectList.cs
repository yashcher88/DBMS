using System.Collections.Generic;
using System.Text.Json.Nodes;

namespace DBMS.Classes
{
    public class StyleObjectList
    {
        public Dictionary<string,StyleObject> List = new Dictionary<string,StyleObject>();
        public void Add(string Name) 
        {
            if (!List.ContainsKey(Name))
            {
                List[Name] = new StyleObject();
            }
        }
        public void Delete(string Name)
        {
            List.Remove(Name);
        }
        public void Change(string OldName, string NewName)
        {
            StyleObject M = new StyleObject();
            if (List.ContainsKey(OldName)) 
            {
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
                var USC = new StyleObject();
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
