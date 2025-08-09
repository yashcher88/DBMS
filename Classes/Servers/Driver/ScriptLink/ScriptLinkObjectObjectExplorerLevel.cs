using DBMS.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using DBMS.Functions;
using System.Threading.Tasks;

namespace DBMS.Classes
{
    public class ScriptLinkObjectObjectExplorerLevel
    {
        ObjectExplorerNodeType NodeType;
        string ParameterName;

        public void LoadScriptLinkObjectObjectExplorerNodeFromJson(JsonObject J)
        {
            NodeType = CConvert.StringToObjectExplorerNodeType(J["NodeType"].ToString());
            ParameterName = J["ParameterName"].ToString();
        }
        public JsonObject SaveScriptLinkObjectObjectExplorerNodeToJson()
        {
            JsonObject J = new JsonObject();
            J["NodeType"] = CConvert.ObjectExplorerNodeTypeToString(NodeType);
            J["ParameterName"] = ParameterName;
            return J;
        }
    }
}
