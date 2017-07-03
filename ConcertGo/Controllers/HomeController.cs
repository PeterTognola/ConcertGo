using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using RestSharp;
using TM.Discovery;
using TM.Discovery.V2;
using TM.Discovery.V2.Models;

namespace ConcertGo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public async Task<string> TicketMasterTest(TicketViewModel ticketViewModel) // todo refactor
        {
            var config = new TicketMasterConfig(System.IO.File.ReadAllText(Server.MapPath("~/TicketMasterKey.txt")), // wrong key.
                "https://app.ticketmaster.com/discovery/");

            var restClient = new RestClient(config.ApiRootUrl);

            var eventsApiClient = new EventsClient(restClient, config);
            
            var search = new SearchEventsRequest();

            search.AddQueryParameter(new KeyValuePair<SearchEventsQueryParameters, string>(SearchEventsQueryParameters.latlong, $"{ticketViewModel.Lat},{ticketViewModel.Long}")); // todo to geo hash.

            //search.AddQueryParameter(new KeyValuePair<SearchEventsQueryParameters, string>(TM.Discovery.V2.Models.SearchEventsQueryParameters.geoPoint, $"{ticketViewModel.Lat},{ticketViewModel.Long}")); // todo to geo hash.

            var a = new SearchVenuesRequest();

            var result = await eventsApiClient.SearchEventsAsync(search); // result location: result > _embedded. todo base off location.

            return "";
        }
    }

    public class TicketViewModel // todo refactor.
    {
        public string GeoHash { get; set; }

        public string Lat { get; set; }

        public string Long { get; set; }
    }

    public class TicketMasterConfig : IClientConfig {
        public TicketMasterConfig(string consumerKey, string apiRootUrl)
        {
            ConsumerKey = consumerKey;
            ApiRootUrl = apiRootUrl;
        }

        public string ConsumerKey { get; }
        public string ApiRootUrl { get; }
    }
}