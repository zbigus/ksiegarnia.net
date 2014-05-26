using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;
using System.Web.Http.Results;
using BookStore.SPA.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using BookStore.Logic.Interfaces;
using BookStore.Entities.Models;
using BookStore.Logic.Models;
using Newtonsoft.Json;

namespace BookStore.UnitTests.Controllers
{
    [TestClass]
    public class BookControllerTest
    {
        static Mock<IRepository> _mockUserRepo = new Mock<IRepository>();
        
        BooksController booksController = new BooksController(_mockUserRepo.Object);

        [TestMethod]
        public void GetAllBooks_ShouldReturnTypeOkNegotiatedContentResult()
        {
            var result = booksController.Get();
            Assert.IsTrue(result.GetType() == typeof(OkNegotiatedContentResult<IEnumerable<BookModel>>));
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetInitialData_ShouldReturnTypeSimpleBookModel()
        {
            var result = booksController.GetInitialData();
            Assert.IsTrue(result.GetType() == typeof(OkNegotiatedContentResult<IEnumerable<SimpleBookModel>>));
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetBookByIDWithExistingID_ShouldReturnTypeOkResult()
        {
            _mockUserRepo.Setup(m => m.GetBookById(It.IsAny<int>())).Returns(new Book());
            var result = booksController.Get(It.IsAny<int>());
            Assert.IsTrue(result.GetType() == typeof(OkNegotiatedContentResult<BookModel>));
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetBookByIDWithNonExistingID_ShouldReturnTypeOkResult()
        {
            _mockUserRepo.Setup(m => m.GetBookById(It.IsAny<int>())).Returns(default(Book));
            var result = booksController.Get(It.IsAny<int>());
            Assert.IsTrue(result.GetType() == typeof(NotFoundResult));
            Assert.IsNotNull(result);
        }

       [TestMethod]
        public void DeleteWithNonExistingId_ShouldReturnTypeNotFound()
        {
            _mockUserRepo.Setup(m => m.DeleteBook(It.IsAny<int>())).Returns(false);
            var result = booksController.Delete(It.IsAny<int>());
            Assert.IsTrue(result.GetType() == typeof(NotFoundResult));
        }

        [TestMethod]
        public void DeleteWithExistingId_ShouldReturnTypeOkResult()
        {
            _mockUserRepo.Setup(m => m.DeleteBook(It.IsAny<int>())).Returns(true);
            var result = booksController.Delete(It.IsAny<int>());
            Assert.IsTrue(result.GetType() == typeof(OkResult));
        }

        /*[TestMethod]
        public void PostWithExistingId_ShouldReturnConflict()
        {
            int i;
            _mockUserRepo.Setup(m => m.AddBook(It.IsAny<BookModel>(),It.IsAny<List<string>>(),out i)).Returns(true);
            var result = booksController.Post(It.IsAny<object[]>());
            Assert.IsTrue(result.GetType() == typeof(CreatedAtRouteNegotiatedContentResult<BookModel>));
        }*/
    }
}
