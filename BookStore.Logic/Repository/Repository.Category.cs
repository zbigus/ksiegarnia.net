using BookStore.Entities.Models;
using System.Collections.Generic;
using System.Linq;
using BookStore.Logic.Models;

namespace BookStore.Logic.Repository
{
    public partial class Repository
    {
        public IEnumerable<CategoryModel> GetCategories()
        {
            return _db.Categories.Select(category => CategoryModel.Create(category)).ToList();
        }

        public bool AddCategory(string name)
        {
            if (_db.Categories.FirstOrDefault(s=> s.Name == name) != null)
                return false;
            _db.Categories.Add(new Category{Name = name});
            _db.SaveChanges();
            return true;
        }

        public bool DeleteCategory(int id)
        {
            var category = _db.Categories.Find(id);
            if (category == null)
                return false;
            _db.Categories.Remove(category);
            return true;
        }
    }
}
