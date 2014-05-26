using System.Collections.Generic;
using BookStore.Logic.Models;

namespace BookStore.Logic.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<CategoryModel> GetCategories();
        bool AddCategory(string name);
        bool DeleteCategory(int id);
    }
}
