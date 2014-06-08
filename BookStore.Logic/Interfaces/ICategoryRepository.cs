using System.Collections.Generic;
using System.Linq;
using BookStore.Entities.Models;
using BookStore.Logic.Models;

namespace BookStore.Logic.Interfaces
{
    public interface ICategoryRepository
    {
        CategoryModel GetCategory(int id);
        List<CategoryModel> GetCategories();
        bool AddCategory(string name);
        bool AddBookCategory(int categoryId, int bookId);
        void AddBookCategories(int bookId, IEnumerable<int> categories);
        void AddDeleteBookCatedories(int bookId, IEnumerable<int> categories);
        bool DeleteCategory(int id);
        bool DeleteBookCategory(int categoryId, int bookId);
        void DeleteBookCategories(int bookId, IEnumerable<int> categories);
        void ClearBookCategories(int bookId);
        bool UpdateCategory(CategoryModel category);
        bool CategoryExists(int id);
        bool CategoryExists(string name);
    }
}