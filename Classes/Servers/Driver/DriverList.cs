using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace DBMS.Classes
{
    public class DriverList
    {
        public Dictionary<string,Driver> List = new Dictionary<string,Driver>();
        public void LoadDriversFromJson(JsonObject J) 
        {
            List.Clear();
            foreach (var driver in J) 
            {
                var D = new Driver(driver.Key);
                D.LoadFromZip(driver.Value.AsObject());
                List.Add(driver.Key, D);
            }
        }
        public JsonObject SaveDriversToJson() 
        {
            JsonObject J = new JsonObject();
            foreach (var driver in List)
            {
                J[driver.Key] = driver.Value.SaveToZip();
            }
            return J;
        }
    }
}
