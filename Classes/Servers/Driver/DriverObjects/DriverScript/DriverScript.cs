using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace DBMS.Classes
{
    public class DriverScript
    {
        public string Script;
        public int MinVersion;
        public int MaxVersion;
        public bool ExecBeforeOpen;
        public void LoadDriverScriptFromJson(JsonObject J)
        {
            Script = J["Script"].ToString();
            MinVersion = Convert.ToInt32(J["MinVersion"]?.ToString() ?? "0");
            MaxVersion = Convert.ToInt32(J["MaxVersion"]?.ToString() ?? "1000000000");
            ExecBeforeOpen = Convert.ToBoolean(J["ExecBeforeOpen"].ToString());
        }
        public JsonObject SaveDriverScriptToJson()
        {
            JsonObject J = new JsonObject();
            J["Script"] = Script;
            J["MinVersion"] = MinVersion;
            J["MaxVersion"] = MaxVersion;
            J["ExecBeforeOpen"] = ExecBeforeOpen;
            return J;
        }

    }
}
