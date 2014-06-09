using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Http.Results;
using BookStore.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using BookStore.Logic.Interfaces;
using BookStore.Entities.Models;
using BookStore.Logic.Models;
using Newtonsoft.Json;

namespace BookStore.UnitTests.Controllers
{
    
    [TestClass]
    public class BookControllerTest : BaseTestControllersClass
    {
        
        BooksController booksController = new BooksController(_mockUserRepo.Object);

        [TestMethod]
        public void GetAllBooks_ShouldReturnTypeListBookModel()
        {
            _mockUserRepo.Setup(m => m.GetBooks()).Returns(new List<SimpleBookModel>());
            var result = booksController.Get();
            Assert.IsTrue(result.GetType() == typeof(List<SimpleBookModel>));
        }
        
        [TestMethod]
        public void GetBookByIDWithExistingID_ShouldReturnTypeBookModel()
        {
            _mockUserRepo.Setup(m => m.GetBook(It.IsAny<int>())).Returns(new BookModel());
            var result = booksController.Get(It.IsAny<int>());
            Assert.IsTrue(result.GetType() == typeof(BookModel));
        }
        
        /*[TestMethod]
        public void GetBookByIDWithNonExistingID_ShouldReturnTypeOkResult()
        {
            _mockUserRepo.Setup(m => m.GetBook(It.IsAny<int>())).Returns(null);
            var result = booksController.Get(It.IsAny<int>());
            Assert.IsTrue(result.GetType() == null);
        }*/

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

        [TestMethod]
        public void PostWithExistingId_ShouldReturnConflict()
        {
            int i;
            _mockUserRepo.Setup(m => m.AddBook(It.IsAny<BookModel>())).Returns(true);
            var result = booksController.Post(It.IsAny<BookModel>());
            Assert.IsTrue(result.GetType() == typeof(CreatedAtRouteNegotiatedContentResult<BookModel>));
        }
    }
}
