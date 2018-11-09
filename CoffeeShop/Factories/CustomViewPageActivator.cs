namespace CoffeeShop.Factories
{
    using System;
    using System.Web.Mvc;
    using Microsoft.Practices.Unity;

    public class CustomViewPageActivator : IViewPageActivator
    {
        //CustomViewPageActivator is responsible for managing the creation of a view by using a Unity container.

        private IUnityContainer container;

        public CustomViewPageActivator(IUnityContainer container)
        {
            this.container = container;
        }

        public object Create(ControllerContext controllerContext, Type type)
        {
            return this.container.Resolve(type);
        }
    }
}