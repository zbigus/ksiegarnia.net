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
        private readonly Book _book;

        public OrdersRepositoryTest()
        {
            var context = new BookStoreContext();
            _user = context.Users.First(arg => arg.UserName.StartsWith("User"));
            _book = context.Books.First();
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

        [TestMethod]
        public void GetIncorectOrder()
        {
            var order = _repository.GetOrder(0);
            Assert.IsNull(order);
            var orderId = _repository.GetOrders().OrderBy(arg => arg.Id).Last().Id;
            order = _repository.GetOrder(orderId + 1);
            Assert.IsNull(order);
        }

        [TestMethod]
        public void AddOrder()
        {
            var status = _repository.AddOrder(_book.Id, _user.Id);
            Assert.IsTrue(status);
            var orderId = _repository.GetOrders().OrderBy(arg => arg.Id).Last().Id;
            var newOrder = _repository.GetOrder(orderId);
            Assert.AreEqual(OrderStatus.Ordered, newOrder.Status);
            Assert.AreEqual(_user.UserName, newOrder.UserName);
            Assert.AreEqual(_book.Description, newOrder.BookDescription);
            Assert.AreEqual(_book.Title, newOrder.BookTitle);
            Assert.IsTrue(string.IsNullOrEmpty(newOrder.ShopComment));
        }

        [TestMethod]
        public void UpdateOrderStatus()
        {
            const OrderStatus status = OrderStatus.Ordered;
            const OrderStatus newStatus = OrderStatus.Canceled;
            const string comment = "Brak na magazynie";
            var order = _repository.GetOrders(_user.Id, status).First();
            var result = _repository.UpdateOrderStatus(order.Id, newStatus, comment);
            Assert.IsTrue(result);
            var modOrder = _repository.GetOrder(order.Id);
            Assert.AreEqual(comment, modOrder.ShopComment);
            Assert.AreEqual(newStatus, modOrder.Status);
        }

        [TestMethod]
        public void UpdateIncorectOrderStatus()
        {
            const OrderStatus status = OrderStatus.Ready;
            var order = _repository.GetOrders(_user.Id, status).First();
            var result = _repository.UpdateOrderStatus(order.Id, OrderStatus.Ordered);
            Assert.IsFalse(result);
            var orderId = _repository.GetOrders().OrderBy(arg => arg.Id).Last().Id;
            result = _repository.UpdateOrderStatus(orderId + 1, OrderStatus.Executed);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void OrerExists()
        {
            var orderId = _repository.GetOrders().OrderBy(arg => arg.Id).Last().Id;
            var result = _repository.OrderExists(orderId);
            Assert.IsTrue(result);
            result = _repository.OrderExists(orderId + 1);
            Assert.IsFalse(result);
        }
    }
}
