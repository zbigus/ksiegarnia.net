using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Entities.Models;
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
        public void GetAllOrders_ShouldReturnTypeListOrderModel()
        {
            _mockUserRepo.Setup(m => m.GetOrders()).Returns(new List<OrderModel>());
            var result = ordersController.Get();
            Assert.IsTrue(result.GetType() == typeof(List<OrderModel>));
        }

        [TestMethod]
        public void GetOrder_ShouldReturnTypeOrderDetailModel()
        {
            _mockUserRepo.Setup(m => m.GetOrder(It.IsAny<int>())).Returns(new OrderDetailModel());
            var result = ordersController.Get(It.IsAny<int>());
            Assert.IsTrue(result.GetType() == typeof(OrderDetailModel));
        }

        [TestMethod]
        public void GetOrdersWithStatus_ShouldReturnTypeListOrderModel()
        {
            _mockUserRepo.Setup(m => m.GetOrders(It.IsAny<OrderStatus>())).Returns(new List<OrderModel>());
            var result = ordersController.GetOrdersWithStatus(It.IsAny<OrderStatus>());
            Assert.IsTrue(result.GetType() == typeof(List<OrderModel>));
        }

        /*[TestMethod]
        public void GetOrdersForUser_ShouldReturnTypeListOrderModel()
        {
            _mockUserRepo.Setup(m => m.GetOrders(It.IsAny<string>())).Returns(new List<OrderModel>());
            var result = ordersController.GetOrdersForUser();
            Assert.IsTrue(result.GetType() == typeof(List<OrderModel>));
        }
        [TestMethod]
        public void AddOrderWithNonexistingId_ShouldReturnTypeCreatedAtRoute()
        {
            _mockUserRepo.Setup(m => m.AddOrder(It.IsAny<int>(), It.IsAny<string>())).Returns(true);
            var result = ordersController.Post(It.IsAny<int>());
            Assert.IsTrue(result.GetType() == typeof(OkResult));
        }
        [TestMethod]
        public void AddOrderWithExistingId_ShouldReturnTypeConflict()
        {
            _mockUserRepo.Setup(m => m.AddOrder(It.IsAny<int>(), It.IsAny<string>())).Returns(false);
            var result = ordersController.Post(It.IsAny<int>());
            Assert.IsTrue(result.GetType() == typeof(ConflictResult));
        }*/

        [TestMethod]
        public void DropOrderAsAdmin_ShouldReturnTypeOk()
        {
            _mockUserRepo.Setup(m => m.UpdateOrderStatus(It.IsAny<int>(), It.IsAny<OrderStatus>(),It.IsAny<string>())).Returns(true);
            var result = ordersController.DropOrderAsAdmin(It.IsAny<int>());
            Assert.IsTrue(result.GetType() == typeof(OkResult));
        }

        [TestMethod]
        public void DropOrderAsAdmin_ShouldReturnTypeConflict()
        {
            _mockUserRepo.Setup(m => m.UpdateOrderStatus(It.IsAny<int>(), It.IsAny<OrderStatus>(), It.IsAny<string>())).Returns(false);
            var result = ordersController.DropOrderAsAdmin(It.IsAny<int>());
            Assert.IsTrue(result.GetType() == typeof(ConflictResult));
        }
    }
}
