using BookStore.Entities.Dal;
using BookStore.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Logic.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BookStore.UnitTests.Repository
{
    [TestClass]
    public class CategoriesRepositoryTest
    {
        private readonly Logic.Repository.Repository _repository;
        private readonly User _user;
        private readonly Book _book;

        public CategoriesRepositoryTest()
        {
            var context = new BookStoreContext();
            _user = context.Users.First(arg => arg.UserName.StartsWith("User"));
            _book = context.Books.First();
            _repository = new Logic.Repository.Repository();
        }

        [TestMethod]
        public void GetAllCategories()
        {
            var result = _repository.GetCategories();
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
            Assert.IsTrue(result.GetType() == typeof(List<CategoryModel>));
        }

        [TestMethod]
        public void GetExistingCategory()
        {
            var result = _repository.GetCategory(1);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.GetType() == typeof(CategoryModel));
        }

        [TestMethod]
        public void GetNonExistingCategory()
        {
            var result = _repository.GetCategory(0);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void AddExistingCategory()
        {
            var existingCategoryName = _repository.GetCategory(1).Name;
            var result = _repository.AddCategory(existingCategoryName);
            Assert.IsTrue(result == false);
        }

    }
}
