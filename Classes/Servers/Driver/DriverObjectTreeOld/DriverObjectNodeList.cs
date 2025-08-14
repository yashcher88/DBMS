using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace DBMS.Classes
{
    public class DriverObjectNodeList
    {
        public Dictionary<string,DriverObjectNode> List = new Dictionary<string, DriverObjectNode>();
        public void LoadFromJson(JsonObject J)
        {
            foreach (var node in J.AsObject())
            {
                DriverObjectNode nodeObj = new DriverObjectNode();
                nodeObj.LoadFromJson(node.Value.AsObject());
                List.Add(node.Key, nodeObj);
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
