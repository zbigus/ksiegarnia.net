using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dependencies;
using BookStore.Logic.Interfaces;
using BookStore.Logic.Managers;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Practices.Unity;

namespace BookStore.Controllers
{
    /// <summary>
    /// Klasa bazowa dla kontrolerów
    /// </summary>
    public class BaseApiController : ApiController
    {
        /// <summary>
        /// Instancja repozytorium
        /// </summary>
        public IRepository Repo { get; private set; }

        private UserManager _userManager;
        /// <summary>
        /// Instancja menadżera użytkowników
        /// </summary>
        public UserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.Current.GetOwinContext().GetUserManager<UserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="repo">Interfejs repozytorium</param>
        public BaseApiController(IRepository repo)
        {
            Repo = repo;
            UserManager = UserManager.Create();
        }

    }

    /// <summary>
    /// Kontener do dependency injection
    /// </summary>
    public class UnityResolver : IDependencyResolver
    {
        protected IUnityContainer Container;

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="container">Interfejs definiujący kontener</param>
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
