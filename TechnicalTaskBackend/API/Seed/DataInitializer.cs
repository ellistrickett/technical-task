using API.Context;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace API.Data
{
    public class DataInitializer
    {
        public static async Task SeedData(AlertDbContext context)
        {
            if (!context.Alerts.Any())
            {
                string alertsJSON = File.ReadAllText(@"Seed" + Path.DirectorySeparatorChar + "alerts.json");

                var jsonArray = JArray.Parse(alertsJSON);

                var alertList = new List<Alert>();

                for (var i = 0; i < jsonArray.Count; i++)
                {
                    var data = JObject.Parse(jsonArray[i].ToString());
                    var alertJson = data["alert"].ToString();
                    alertList.Add(JsonConvert.DeserializeObject<Alert>(alertJson));
                }            

                await context.Alerts.AddRangeAsync(alertList);
                await context.SaveChangesAsync();

            }
        }
    }
}
