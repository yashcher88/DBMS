using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace DBMS.Classes
{
    public class DriverInfo
    {
        public string Caption;
        public string DriverName;
        public int DefaultPort;
        public string DefaultDB;
        public string DefaultCodePage;
        public ScriptLink ServerVersion;
        public ScriptLink Pid;
        public ScriptLink Terminate;
        public void LoadDriverInfoFromJson(JsonObject J)
        {
            Caption = J["Caption"].ToString();
            DriverName = J["DriverName"].ToString();
            DefaultPort = Convert.ToInt32(J["DefaultPort"].ToString());
            DefaultDB = J["DefaultDB"].ToString();
            DefaultCodePage = J["DefaultCodePage"].ToString();
        }
        public JsonObject SaveDriverInfoToJson()
        {
            JsonObject J = new JsonObject();

            return J;
        }
    }
}
