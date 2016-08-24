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
        private Topspot[] Topspots;

        public TopspotsController()
        {
            string jsonString = File.ReadAllText(@"D:\Dev\OCA\TopSpots\TopSpotsApi\TopSpotsApi\App_Data\topspots.json");

            JsonSerializerSettings settings = new JsonSerializerSettings();
            Topspots = JsonConvert.DeserializeObject<Topspot[]>(jsonString);
        }

        // GET: api/Topspots
        public IEnumerable<Topspot> Get()
        {
            return Topspots;
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
