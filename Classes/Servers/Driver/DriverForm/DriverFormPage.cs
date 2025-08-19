using DBMS.Enums;
using DBMS.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace DBMS.Classes
{
    public class DriverFormPage
    {
        public FormPageType PageType;
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
