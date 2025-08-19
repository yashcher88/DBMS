using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace DBMS.Classes
{
    public class DriverPopupEvent
    {
        public void LoadFromJson(JsonObject J)
        {

        }
        public JsonObject SaveToJson()
        {
            JsonObject J = new JsonObject();
            return J;
        }
    }
}
