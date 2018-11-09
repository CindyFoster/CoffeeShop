using CoffeeShop.Filters;
using System.Web.Mvc;
using CoffeeShop.Services;

namespace CoffeeShop.Controllers
{
    public class DrinksController : Controller

        //TODO: add a restaurant map, allow servers to see the map and what's available and who's sitting where. Put the regulars in their favourite spots.
        //TODO: Add Events (shows, book readings, game nights) allow people to sign up
        //TODO: Pictures and comments that users have tagged online.
        //TODO: Add sales for the night.
    {
        //you will include services into your controllers to separate the logic from the data access. 
        //The services will create a new dependency in the controller constructor, which will be resolved using Dependency Injection with the help of Unity.

        private RestaurantService service;

        public DrinksController(RestaurantService service)
        {
            this.service = service;
        }

        // GET: Drinks
        [CustomActionFilter]
        public ActionResult Index()
        {
            return View(service.GetDrinkList());
        }
    }
}