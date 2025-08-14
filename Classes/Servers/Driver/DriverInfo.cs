using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace DBMS.Classes.Servers.Driver
{
    public class DriverInfo
    {
        public string Caption;
        public string DriverName;
        public int DefaultPort;
        public string DefaultDB;
        public string DefaultCodePage;
        public DriverScriptLink ServerVersion;
        public DriverScriptLink Pid;
        public DriverScriptLink Terminate;
        public void LoadDriverInfoFromJson(JsonObject J)
        {
            Caption = J["Caption"].ToString();
            DriverName = J["DriverName"].ToString();
            DefaultPort = Convert.ToInt32(J["DefaultPort"].ToString());
            DefaultDB = J["DefaultDB"].ToString();
            DefaultCodePage = J["DefaultCodePage"].ToString();
            ServerVersion = new DriverScriptLink();
            ServerVersion.LoadFromJson(J["ServerVersion"].AsObject());
            Pid = new DriverScriptLink();
            Pid.LoadFromJson(J["Pid"].AsObject());
            Terminate = new DriverScriptLink();
            Terminate.LoadFromJson(J["Terminate"].AsObject());

        }
        public JsonObject SaveDriverInfoToJson()
        {
            JsonObject J = new JsonObject();
            J["Caption"] = Caption;
            J["DriverName"] = DriverName;
            J["DefaultPort"] = DefaultPort;
            J["DefaultDB"] = DefaultDB;
            J["DefaultCodePage"] = DefaultCodePage;
            J["ServerVersion"] = ServerVersion.SaveToJson();
            J["Pid"] = Pid.SaveToJson();
            J["Terminate"] = Terminate.SaveToJson();
            return J;
        }
    }
}
