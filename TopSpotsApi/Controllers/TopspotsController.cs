using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Net.Http.Formatting;
using System.Web;
using TopSpotsApi.Models;

namespace TopSpotsApi.Controllers
{
    public class TopspotsController : ApiController
    {
        private List<Topspot> topspots;
        private JsonSerializerSettings serializerSettings;
                
        // Constructor
        public TopspotsController()
        {
            serializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Formatting = Formatting.Indented
            };

            topspots = GetTopspots();
        }    

        // GET: api/Topspots
        public IEnumerable<Topspot> Get()
        {
            return topspots;
        }

        // GET: api/Topspots/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/Topspots
        public HttpResponseMessage Post([FromBody] Topspot topspot)
        {
            if (topspot != null)
            {
                topspots.Add(topspot);
                WriteTopspots(topspots);
                string jsonString = JsonConvert.SerializeObject(topspot, serializerSettings);

                return Request.CreateResponse(HttpStatusCode.OK, jsonString);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "JSON object malformed");
            }
        }

        private List<Topspot> GetTopspots()
        {
            string jsonString = File.ReadAllText(HttpContext.Current.Server.MapPath("../App_Data/topspots.json"));

            return JsonConvert.DeserializeObject<List<Topspot>>(jsonString, serializerSettings);
        }


        private void WriteTopspots(IEnumerable<Topspot> topspots)
        {
            string jsonString = JsonConvert.SerializeObject(topspots, serializerSettings);

            File.WriteAllText(HttpContext.Current.Server.MapPath("../App_Data/TopSpots.json"), jsonString);
        }
    }
}
