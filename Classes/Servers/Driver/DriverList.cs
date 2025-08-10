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
        public Dictionary<string,Driver> Drivers = new Dictionary<string,Driver>();
        public void LoadDriversFromJson(JsonObject J) 
        {
            Drivers.Clear();
            foreach (var driver in J) 
            {
                var D = new Driver(driver.Key);
                D.LoadDriverFromZip(driver.Value.AsObject());
                Drivers.Add(driver.Key, D);
            }
        }
        public JsonObject SaveDriversToJson() 
        {
            JsonObject J = new JsonObject();
            foreach (var driver in Drivers)
            {
                J[driver.Key] = driver.Value.SaveDriverToZip();
            }
            return J;
        }
    }
}
