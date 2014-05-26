using System;
using System.Runtime.Serialization;
using BookStore.Entities.Models;

namespace BookStore.Logic.Models
{
    [DataContract]
    public class CategoryModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public String Name { get; set; }

        public CategoryModel(Category category)
        {
            Id = category.Id;
            Name = category.Name;
        }

        public static CategoryModel Create(Category category)
        {
            return new CategoryModel(category);
        }
    }
}