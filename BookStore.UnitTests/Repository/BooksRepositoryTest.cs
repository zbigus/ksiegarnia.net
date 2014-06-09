using BookStore.Entities.Dal;
using BookStore.Entities.Models;
using BookStore.Logic.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.UnitTests.Repository
{
    [TestClass]
    public class BooksRepositoryTest
    {
        private readonly Logic.Repository.Repository _repository;
        private readonly Book _book;

        public BooksRepositoryTest()
        {
            var context = new BookStoreContext();
            _book = context.Books.First();
            _repository = new Logic.Repository.Repository();
        }

        [TestMethod]
        public void GetAllBooks()
        {
            var books = _repository.GetBooks();
            Assert.IsNotNull(books);
            Assert.IsTrue(books.Count > 0);
        }
        [TestMethod]
        public void GetFirstBook()
        {
            var book = _repository.GetBook(1);
            Assert.IsNotNull(book);
            Assert.IsTrue(_book.Title == book.Title);
        }

        [TestMethod]
        public void GetBooksContainingPhrase()
        {
            var phrase = _repository.GetBooks().First().Title;
            var book = _repository.SearchBooks(phrase);
            Assert.IsNotNull(book);
            Assert.IsTrue(book.Count > 0);
        }
        [TestMethod]
        public void AddBookWithExistingId()
        {
            var bookModel = BookModel.Create(_book);
            var result = _repository.AddBook(bookModel);
            Assert.IsNotNull(bookModel);
            Assert.IsTrue(result == false);
        }

        [TestMethod]
        public void UpdateBookWithExistingId()
        {
            var bookModel = BookModel.Create(_book);
            bookModel.Price = 19;
            var result = _repository.UpdateBook(bookModel);
            Assert.IsNotNull(bookModel);
            Assert.IsTrue(result == true);
        }
        [TestMethod]
        public void GetTopSaleBooks()
        {
            var result = _repository.GetTopSaleBooks();
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count <= 10);
        }
        [TestMethod]
        public void GetLatestBooks()
        {
            var result = _repository.GetTopNewBooks();
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count <= 5);
        }

        [TestMethod]
        public void GetBooksFromExistingCategory()
        {
            var result = _repository.GetBooksByCategory(1);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void GetBooksFromNonExistingCategory()
        {
            var result = _repository.GetBooksByCategory(0);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count == 0); ;
        }
        [TestMethod]
        public void BookNotExists()
        {
            var result = _repository.BookExists(0);
            Assert.IsTrue(result == false); 
        }

       

    }
}
