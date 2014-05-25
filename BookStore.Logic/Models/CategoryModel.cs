using System;
using System.Collections.Generic;

namespace BookStore.Logic.Models
{
    public class CategoryModel
    {
        public String Name { get; set; }
        public List<BookModel> Books { get; set; }
    }
}