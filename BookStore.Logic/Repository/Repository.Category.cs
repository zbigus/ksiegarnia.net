using BookStore.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Logic.Models;

namespace BookStore.Logic.Repository
{
    partial class Repository
    {
        public IQueryable<Category> GetAllCategories()
        {
            return _db.Categories.AsQueryable();
        }

        public bool AddCategory(string name, out int id)
        {
            if (_db.Categories.FirstOrDefault(s=> s.Name == name) != null)
            {
                id = 0;
                return false;
            }
            var category = new Category
            {
                Name = name
            };
            _db.Categories.Add(category);
            _db.SaveChanges();
            id = category.Id;
            return true;
        }
        public bool DeleteCategory(int id)
        {
            var category = _db.Categories.Find(id);
            if (category == null)
            {
                return false;
            }
            _db.Categories.Remove(category);
            _db.SaveChanges();
            return true;
        }
        
    }
}
