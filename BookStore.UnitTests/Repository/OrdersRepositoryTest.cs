using System.Linq;
using BookStore.Entities.Dal;
using BookStore.Entities.Helpers;
using BookStore.Entities.Models;
using BookStore.Logic.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BookStore.UnitTests.Repository
{
    [TestClass]
    public class OrdersRepositoryTest
    {
        private readonly Logic.Repository.Repository _repository;
        private readonly User _user;

        public OrdersRepositoryTest()
        {
            var context = new BookStoreContext();
            _user = context.Users.First(arg => arg.UserName.StartsWith("User"));
            _repository = new Logic.Repository.Repository();
        }

        [TestMethod]
        public void GetAllOrders()
        {
            var orders = _repository.GetOrders();
            Assert.IsNotNull(orders);
            Assert.IsTrue(orders.Count > 0);
        }

        [TestMethod]
        public void GetAllOrdersWithStatus()
        {
            const OrderStatus status = OrderStatus.Ordered;
            var statusName = status.GetAttribute<ResxAttribute>().Name;
            var orders = _repository.GetOrders(status);
            Assert.IsNotNull(orders);
            Assert.IsTrue(orders.Count > 0);
            foreach (var orderModel in orders)
            {
                Assert.AreEqual(status, orderModel.Status);
                Assert.AreEqual(statusName, orderModel.StatusName);
            }
        }

        [TestMethod]
        public void GetUserOrders()
        {
            var orders = _repository.GetOrders(_user.Id);
            Assert.IsNotNull(orders);
            Assert.IsTrue(orders.Count > 0);
        }

        [TestMethod]
        public void GetUserOrdersWithStatus()
        {
            const OrderStatus status = OrderStatus.Ordered;
            var statusName = status.GetAttribute<ResxAttribute>().Name;
            var orders = _repository.GetOrders(_user.Id, status);
            Assert.IsNotNull(orders);
            Assert.IsTrue(orders.Count > 0);
            foreach (var orderModel in orders)
            {
                Assert.AreEqual(status, orderModel.Status);
                Assert.AreEqual(statusName, orderModel.StatusName);
            }
        }

        [TestMethod]
        public void GetOrder()
        {
            const OrderStatus status = OrderStatus.Ordered;
            var statusName = status.GetAttribute<ResxAttribute>().Name;
            var orders = _repository.GetOrders(_user.Id, status);
            Assert.IsNotNull(orders);
            Assert.IsTrue(orders.Count > 0);
            var order = _repository.GetOrder(orders[0].Id);
            Assert.IsNotNull(order);
            Assert.AreEqual(status, order.Status);
            Assert.AreEqual(statusName, order.StatusName);
            Assert.AreEqual(_user.UserName, order.UserName);
        }

    }
}
