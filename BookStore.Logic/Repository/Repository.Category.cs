using BookStore.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Logic.Repository
{
    public partial class Repository
    {
        public IQueryable<Category> GetAllCategories()
        {
            return _db.Categories.AsQueryable();
        }

        public bool AddCategory(string name)
        {
            if (_db.Categories.FirstOrDefault(s=> s.Name == name) != null)
            {
                return false;
            }
            _db.Categories.Add(new Category{Name = name});
            _db.SaveChanges();
            return true;
        }
        
    }
}
