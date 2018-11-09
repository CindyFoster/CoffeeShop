namespace CoffeeShop.Factories
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Microsoft.Practices.Unity;

    public class UnityDependencyResolver : IDependencyResolver
    {
        //UnityDependencyResolver class is a custom DependencyResolver for Unity. When a service cannot be found inside the Unity container, the base resolver is invocated.

        private IUnityContainer container;

        private IDependencyResolver resolver;

        public UnityDependencyResolver(IUnityContainer container, IDependencyResolver resolver)
        {
            this.container = container;
            this.resolver = resolver;
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return this.container.Resolve(serviceType);
            }
            catch
            {
                return this.resolver.GetService(serviceType);
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return this.container.ResolveAll(serviceType);
            }
            catch
            {
                return this.resolver.GetServices(serviceType);
            }
        }
    }
}