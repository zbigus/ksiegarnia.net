using System.ComponentModel.DataAnnotations;
using BookStore.Entities.Models;

namespace BookStore.Logic.Models
{
    public class CategoryModel
    {
        public CategoryModel()
        {
        }

        public CategoryModel(Category category)
        {
            Id = category.Id;
            Name = category.Name;
        }

        public int Id { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "{0} nie mo�e zawiera� wi�cej ni� {1} znak�w.")]
        public string Name { get; set; }

        public static CategoryModel Create(Category category)
        {
            return new CategoryModel(category);
        }
    }
}