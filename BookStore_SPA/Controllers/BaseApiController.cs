using BookStore.Entities.Models;
using BookStore.Logic.Models;
using BookStore.Logic.Repository;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Dependencies;



namespace BookStore_SPA.Controllers
{
    public class BaseApiController : ApiController
    {
        private static IRepository _repo ;
        
        protected static IRepository Repo {
            get {
                return _repo;
            }
        }

        protected ModelFactory ModelFactory;

        protected ModelFactory TheModelFactory
        {
            get
            {
                if (ModelFactory == null)
                {
                    ModelFactory = new ModelFactory();
                }
                return ModelFactory;
            }
        }
        
        public BaseApiController(IRepository repo) {
            _repo = repo;
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
