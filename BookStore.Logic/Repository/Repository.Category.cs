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
            var category = GetCategoryImpl(id);
            return category == null ? null : CategoryModel.Create(category);
        }

        public List<CategoryModel> GetCategories()
        {
            return GetCategoriesImpl()
                .Select(CategoryModel.Create)
                .ToList();
        }

        public bool AddCategory(string name)
        {
            if (CategoryExists(name))
                return false;
            var category = new Category
            {
                Name = name
            };
            _db.Categories.Add(category);
            _db.SaveChanges();
            return true;
        }

        public bool AddBookCategory(int categoryId, int bookId)
        {
            if (!CategoryExists(categoryId))
                return false;
            _db.BookCategories.Add(new BookCategory {BookId = bookId, CategoryId = categoryId});
            return true;
        }

        public bool DeleteCategory(int id)
        {
            var category = GetCategoryImpl(id);
            if (category == null)
                return false;
            _db.Categories.Remove(category);
            _db.SaveChanges();
            return true;
        }

        public bool DeleteBookCategory(int categoryId, int bookId)
        {
            if (!CategoryExists(categoryId))
                return false;
            var bookCategory =
                _db.BookCategories.FirstOrDefault(arg => arg.BookId == bookId && arg.CategoryId == categoryId);
            if (bookCategory == null)
                return false;
            _db.BookCategories.Remove(bookCategory);
            return true;
        }

        public bool UpdateCategory(CategoryModel category)
        {
            var cat = GetCategoryImpl(category.Id);
            if (cat == null)
                return false;
            cat.Name = category.Name;
            _db.SaveChanges();
            return true;
        }

        public bool CategoryExists(int id)
        {
            return GetCategoryImpl(id) != null;
        }

        public bool CategoryExists(string name)
        {
            return _db.Categories.FirstOrDefault(s => s.Name == name) != null;
        }

        public void ClearBookCategories(int bookId)
        {
            var currenCategories = _db.BookCategories.Where(bc => bc.BookId == bookId);
            _db.BookCategories.RemoveRange(currenCategories);
        }

        public void AddBookCategories(int bookId, IEnumerable<int> categories)
        {
            foreach (var categoryId in categories)
            {
                //Nie dodajemy kategorii, które już są w bazie
                var bookCategory = _db.BookCategories
                    .FirstOrDefault(arg => arg.BookId == bookId && arg.CategoryId == categoryId);
                if (bookCategory == null)
                    _db.BookCategories.Add(new BookCategory { BookId = bookId, CategoryId = categoryId });
            }
        }

        private Category GetCategoryImpl(int id)
        {
            return _db.Categories.Find(id);
        }

        private IEnumerable<Category> GetCategoriesImpl()
        {
            return _db.Categories
                .OrderBy(category => category.Name)
                .AsEnumerable();
        }
    }
}