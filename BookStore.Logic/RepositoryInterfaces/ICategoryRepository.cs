using BookStore.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Logic.RepositoryInterfaces
{
    public interface ICategoryRepository
    {
        IQueryable<Category> GetAllCategories();
        bool AddCategory(string name);
    }
}
