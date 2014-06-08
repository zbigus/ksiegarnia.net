using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Logic.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookStore.Logic.Interfaces;
using Moq;
using BookStore.Controllers;
using System.Web.Http.Results;

namespace BookStore.UnitTests.Controllers
{
    [TestClass]
    public class OrdersControllerTest:BaseTestControllersClass
    {
        OrdersController ordersController = new OrdersController(_mockUserRepo.Object);

        [TestMethod]
        public void GetAllOrders_ShouldReturnTypeOkNegotiatedContentResult()
        {
            var result = ordersController.Get();
            Assert.IsTrue(result.GetType() == typeof(OkNegotiatedContentResult<IEnumerable<OrderModel>>));
        }
        /*[TestMethod]
        public void AddOrderWithNonexistingId_ShouldReturnTypeCreatedAtRoute()
        {
            int i;
            _mockUserRepo.Setup(m => m.AddOrder(It.IsAny<OrderModel>(), out i)).Returns(true);
            var result = ordersController.Post(It.IsAny<OrderModel>());
            Assert.IsTrue(result.GetType() == typeof(CreatedAtRouteNegotiatedContentResult<OrderModel>));
        }
        [TestMethod]
        public void AddOrderWithExistingId_ShouldReturnTypeConflict()
        {
            int i;
            _mockUserRepo.Setup(m => m.AddOrder(It.IsAny<OrderModel>(), out i)).Returns(false);
            var result = ordersController.Post(It.IsAny<OrderModel>());
            Assert.IsTrue(result.GetType() == typeof(ConflictResult));
        }*/
        //[TestMethod]
        //public void GetOrderStatus_ShouldReturnTypeOkNegotiatedContext()
        //{
        //    string stats;
        //    _mockUserRepo.Setup(m => m.GetOrderStatus(It.IsAny<int>(), out stats)).Returns(true);
        //    var result = ordersController.GetOrderStatus(It.IsAny<int>());
        //    Assert.IsTrue(result.GetType() == typeof(OkNegotiatedContentResult<string>));
        //}
        //[TestMethod]
        //public void GetOrderStatus_ShouldReturnTypeNotFound()
        //{
        //    string stats;
        //    _mockUserRepo.Setup(m => m.GetOrderStatus(It.IsAny<int>(), out stats)).Returns(false);
        //    var result = ordersController.GetOrderStatus(It.IsAny<int>());
        //    Assert.IsTrue(result.GetType() == typeof(NotFoundResult));
        //}
        //[TestMethod]
        //public void Delete_ShouldReturnTypeNotFound()
        //{
        //    _mockUserRepo.Setup(m => m.DeleteOrder(It.IsAny<int>())).Returns(false);
        //    var result = ordersController.Delete(It.IsAny<int>());
        //    Assert.IsTrue(result.GetType() == typeof(NotFoundResult));
        //}
        //[TestMethod]
        //public void Delete_ShouldReturnTypeOk()
        //{
        //    _mockUserRepo.Setup(m => m.DeleteOrder(It.IsAny<int>())).Returns(true);
        //    var result = ordersController.Delete(It.IsAny<int>());
        //    Assert.IsTrue(result.GetType() == typeof(OkResult));
        //}
    }
}
