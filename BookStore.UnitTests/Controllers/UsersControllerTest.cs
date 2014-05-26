using System.Data.Entity;
using System.Data.Entity.Core.Objects.DataClasses;
using BookStore.Entities.Models;
using BookStore.Logic.Interfaces;
using BookStore.Logic.Models;
using BookStore.SPA.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;

namespace BookStore.UnitTests.Controllers
{

    [TestClass]
    public class UsersControllerTest
    {
        static Mock<IRepository> _mockUserRepo = new Mock<IRepository>();

        UsersController usersController = new UsersController(_mockUserRepo.Object);

        [TestMethod]
        public void GetAllUsers_ShouldReturnTypeNotFound()
        {
            _mockUserRepo.Setup(m => m.GetAllUsers()).Returns(default(IQueryable<User>));
            var result = usersController.Get();
            Assert.IsTrue(result.GetType() == typeof(NotFoundResult));
        }
       
        [TestMethod]
        public void GetUsersByRole_ShouldReturnTypeNotFound()
        {
            _mockUserRepo.Setup(m => m.GetUsersByRole(It.IsAny<string>())).Returns(default(IQueryable<User>));
            var result = usersController.Get(It.IsAny<string>());
            Assert.IsTrue(result.GetType() == typeof(NotFoundResult));
        }
        
        [TestMethod]
        public void GetUsersIDByLogin_ShouldReturnTypeNotFound()
        {
            _mockUserRepo.Setup(m => m.GetUsersIDByLogin(It.IsAny<string>())).Returns(default(IQueryable<User>));
            var result = usersController.Get(It.IsAny<string>());
            Assert.IsTrue(result.GetType() == typeof(NotFoundResult));
        }
    }
}
