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

        public async Task<string> TicketMasterTest()
        {
            var config = new TicketMasterConfig("yxGeZiH33ISWvVKm9nHu2D1JKbEB2sTk", // wrong key.
                "https://app.ticketmaster.com/discovery/");

            var restClient = new RestClient(config.ApiRootUrl);

            var eventsApiClient = new EventsClient(restClient, config);
            var result = await eventsApiClient.SearchEventsAsync(new SearchEventsRequest()); // result location: result > _embedded. todo base off location.

            return "";
        }
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