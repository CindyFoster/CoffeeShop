namespace CoffeeShop.Pages
{
    using Microsoft.Practices.Unity;
    using CoffeeShop.Models;
    using CoffeeShop.Services;

    public class MyBasePage : System.Web.Mvc.WebViewPage<Drinks>
    {
        [Dependency]
        public IMessageService MessageService { get; set; }

        public override void

        Execute()
        {
        }
    }
}
