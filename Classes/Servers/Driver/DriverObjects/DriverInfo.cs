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
            ServerVersion = new ScriptLink();
            ServerVersion.LoadScriptLinkFromJson(J["ServerVersion"].AsObject());
            Pid = new ScriptLink();
            Pid.LoadScriptLinkFromJson(J["Pid"].AsObject());
            Terminate = new ScriptLink();
            Terminate.LoadScriptLinkFromJson(J["Terminate"].AsObject());

        }
        public JsonObject SaveDriverInfoToJson()
        {
            JsonObject J = new JsonObject();
            J["Caption"] = Caption;
            J["DriverName"] = DriverName;
            J["DefaultPort"] = DefaultPort;
            J["DefaultDB"] = DefaultDB;
            J["DefaultCodePage"] = DefaultCodePage;
            J["ServerVersion"] = ServerVersion.SaveScriptLinkToJson();
            J["Pid"] = Pid.SaveScriptLinkToJson();
            J["Terminate"] = Terminate.SaveScriptLinkToJson();
            return J;
        }
    }
}
