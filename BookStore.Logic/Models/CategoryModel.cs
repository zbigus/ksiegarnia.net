using System;
using BookStore.Entities.Models;

namespace BookStore.Logic.Models
{
    public class CategoryModel
    {
        private CategoryModel()
        {
        }

        public CategoryModel(Category category)
        {
            Id = category.Id;
            Name = category.Name;
        }

        public int Id { get; set; }
        public String Name { get; set; }

        public static CategoryModel Create(Category category)
        {
            return new CategoryModel(category);
        }
    }
}