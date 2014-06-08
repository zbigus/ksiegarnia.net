using System.Collections.Generic;
using System.Linq;
using BookStore.Entities.Models;
using BookStore.Logic.Models;

namespace BookStore.Logic.Interfaces
{
    public interface ICategoryRepository
    {
        IQueryable<Category> GetAllCategories();
        bool AddCategory(string name, out int id);

        CategoryModel GetCategory(int id);
        List<CategoryModel> GetCategories();
        bool AddCategory(string name);
        bool AddBookCategory(int categoryId, int bookId);
        bool DeleteCategory(int id);
        bool DeleteBookCategory(int categoryId, int bookId);
        bool UpdateCategory(CategoryModel category);
        bool CategoryExists(int id);
        bool CategoryExists(string name);
        void ClearBookCategories(int bookId);
        void AddBookCategories(int bookId, IEnumerable<int> categories);
    }
}