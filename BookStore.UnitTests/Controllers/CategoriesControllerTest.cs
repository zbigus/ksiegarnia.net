using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;
using BookStore.Controllers;
using BookStore.Logic.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BookStore.UnitTests.Controllers
{
    [TestClass]
    public class CategoriesControllerTest:BaseTestControllersClass
    {
        CategoriesController categoriesController = new CategoriesController(_mockUserRepo.Object);
       
        [TestMethod]
        public void GetCategories_ShouldReturnTypeListCategoryModel()
        {
            _mockUserRepo.Setup(m => m.GetCategories()).Returns(new List<CategoryModel>());
            var result = categoriesController.Get();
            Assert.IsTrue(result.GetType() == typeof(List<CategoryModel>));
        }
        [TestMethod]
        public void GetCategory_ShouldReturnTypeCategoryModel()
        {
            _mockUserRepo.Setup(m => m.GetCategory(It.IsAny<int>())).Returns(new CategoryModel());
            var result = categoriesController.Get(It.IsAny<int>());
            Assert.IsTrue(result.GetType() == typeof(CategoryModel));
        }
        [TestMethod]
        public void UpdateCategory_ShouldReturnTypeOkResult()
        {
            _mockUserRepo.Setup(m => m.UpdateCategory(It.IsAny<CategoryModel>())).Returns(true);
            var result = categoriesController.UpdateCategory(It.IsAny<CategoryModel>());
            Assert.IsTrue(result.GetType() == typeof(OkResult));
        }
        [TestMethod]
        public void UpdateCategory_ShouldReturnTypeConflict()
        {
            _mockUserRepo.Setup(m => m.UpdateCategory(It.IsAny<CategoryModel>())).Returns(false);
            var result = categoriesController.UpdateCategory(It.IsAny<CategoryModel>());
            Assert.IsTrue(result.GetType() == typeof(ConflictResult));
        }
        [TestMethod]
        public void DeleteCategory_ShouldReturnTypeOkResult()
        {
            _mockUserRepo.Setup(m => m.DeleteCategory(It.IsAny<int>())).Returns(true);
            var result = categoriesController.DeleteCategory(It.IsAny<int>());
            Assert.IsTrue(result.GetType() == typeof(OkResult));
        }
        [TestMethod]
        public void DeleteCategory_ShouldReturnTypeNotFound()
        {
            _mockUserRepo.Setup(m => m.DeleteCategory(It.IsAny<int>())).Returns(false);
            var result = categoriesController.DeleteCategory(It.IsAny<int>());
            Assert.IsTrue(result.GetType() == typeof(NotFoundResult));
        }

    }
}
