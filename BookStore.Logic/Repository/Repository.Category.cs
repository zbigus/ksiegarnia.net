using System;
using System.Collections.Generic;
using System.Linq;
using BookStore.Entities.Models;
using BookStore.Logic.Models;

namespace BookStore.Logic.Repository
{
    public partial class Repository
    {
        public IQueryable<Category> GetAllCategories()
        {
            return _db.Categories.AsQueryable();
        }

        public bool AddCategory(string name, out int id)
        {
            if (_db.Categories.FirstOrDefault(s => s.Name == name) != null)
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

        public CategoryModel GetCategory(int id)
        {
            var category = _db.Categories.Find(id);
            return category == null ? null : CategoryModel.Create(category);
        }

        public List<CategoryModel> GetCategories()
        {
            return _db.Categories
                .OrderBy(category => category.Name)
                .AsEnumerable()
                .Select(CategoryModel.Create)
                .ToList();
        }

        public bool AddCategory(string name)
        {
            if (_db.Categories.FirstOrDefault(s => s.Name == name) != null)
                return false;
            var category = new Category
            {
                Name = name
            };
            _db.Categories.Add(category);
            _db.SaveChanges();
            return true;
        }

        public bool DeleteCategory(int id)
        {
            var category = _db.Categories.Find(id);
            if (category == null)
                return false;
            _db.Categories.Remove(category);
            _db.SaveChanges();
            return true;
        }

        public bool UpdateCategory(CategoryModel category)
        {
            var cat = _db.Categories.Find(category.Id);
            if (cat == null)
                return false;
            cat.Name = category.Name;
            _db.SaveChanges();
            return true;
        }
    }
}