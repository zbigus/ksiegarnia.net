using System.Linq;
using BookStore.Entities.Models;

namespace BookStore.Logic.Interfaces
{
    public interface ICategoryRepository
    {
        IQueryable<Category> GetAllCategories();
        bool AddCategory(string name);
    }
}
