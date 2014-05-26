using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Dependencies;
using BookStore.Logic.Interfaces;
using BookStore.Logic.Models;
using Microsoft.Practices.Unity;

namespace BookStore.SPA.Controllers
{
    public class BaseApiController : ApiController
    {
        protected IRepository Repo { get; private set; }

        public BaseApiController(IRepository repo)
        {
            Repo = repo;
        }

    }
    public class UnityResolver : IDependencyResolver
    {
        protected IUnityContainer Container;

        public UnityResolver(IUnityContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }
            Container = container;
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return Container.Resolve(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return Container.ResolveAll(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return new List<object>();
            }
        }

        public IDependencyScope BeginScope()
        {
            var child = Container.CreateChildContainer();
            return new UnityResolver(child);
        }

        public void Dispose()
        {
            Container.Dispose();
        }
    }
}
