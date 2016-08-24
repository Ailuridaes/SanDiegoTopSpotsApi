using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Web.Http;
using TopSpotsApi.Models;

namespace TopSpotsApi.Controllers
{
    public class TopspotsController : ApiController
    {
        // GET: api/Topspots
        public IEnumerable<Topspot> Get()
        {
            //JObject o1 = JObject.Parse(File.ReadAllText(Server.MapPath("~/App_Data/topspots.json"));

            // read JSON directly from a file
            //using (streamreader file = new streamreader(server.mappath("~/app_data/topspots.json")))
            //using (jsontextreader reader = new jsontextreader(file))
            //{
            //    jobject o2 = (jobject)jtoken.readfrom(reader);
            //}
            //return new string[] { "value1", "value2" };

            string jsonString = File.ReadAllText(@"D:\Dev\OCA\TopSpots\TopSpotsApi\TopSpotsApi\App_Data\topspots.json");

            //JsonSerializer serializer = new JsonSerializer();
            JsonSerializerSettings settings = new JsonSerializerSettings();
            //settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            Topspot[] topspots = JsonConvert.DeserializeObject<Topspot[]>(jsonString);

            return topspots;
        }

        // GET: api/Topspots/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/Topspots
        public void Post([FromBody]string value)
        {
        }

    }
}
