using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc3;
using CoffeeShop.Controllers;
using CoffeeShop.Services;
using CoffeeShop.Factories;
using CoffeeShop.Filters;
using CoffeeShop.Models;
using CoffeeShop.DAL;

namespace CoffeeShop
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            //Note: replaced for dependency injection tutorial...
            //DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            DependencyResolver.SetResolver(new Unity.Mvc3.UnityDependencyResolver(container));

            IDependencyResolver resolver = DependencyResolver.Current;

            IDependencyResolver newResolver = new Factories.UnityDependencyResolver(container, resolver);

            DependencyResolver.SetResolver(newResolver);
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();        

            //TODO: Understand container.RegisterType better.
            container.RegisterType<IRestaurantService, RestaurantService>();
            container.RegisterType<IController, HomeController>("Home");
            container.RegisterType<IController, DrinksController>("Drinks");

            container.RegisterInstance<IMessageService>(new MessageService
            {
                Message = "This a message from MessageService!",
                ImageUrl = "/Content/Images/Kitty.JPG"
            });

            container.RegisterType<IViewPageActivator, CustomViewPageActivator>(new InjectionConstructor(container));

            container.RegisterInstance<IFilterProvider>("FilterProvider", new FilterProvider(container));
            container.RegisterInstance<IActionFilter>("LogActionFilter", new TraceActionFilter());

            container.RegisterType<IActionLogDAL, ActionLogDAL>();

            return container;
        }
    }
}