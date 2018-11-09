using System.Web.Mvc;
using CoffeeShop.Filters;
using CoffeeShop.Services;

namespace CoffeeShop.Controllers
{
    public class HomeController : Controller
    {
        private RestaurantService service;

        public HomeController(RestaurantService service)
        {
            this.service = service;
        }

        [CustomActionFilter]
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

        public ActionResult ActionLog()
        {   
            //TODO: learn to pass a JSON object
            //TODO: try using Moustache to render the data control
            return View(service.GetAllActionLogs());
        }

        public ActionResult Drinks()
        {
            return View(service.GetAllDrinks());
        }
    }
}