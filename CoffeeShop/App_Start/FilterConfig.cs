using System.Web;
using System.Web.Mvc;
using CoffeeShop.Filters;

namespace CoffeeShop
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new MyNewCustomActionFilter());
        }
    }
}
