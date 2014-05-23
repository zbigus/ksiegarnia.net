using System;
using System.Collections.Generic;
<<<<<<< HEAD
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
=======
>>>>>>> 904c21be24cf3fe30bbe7be1c2a6c1da5d4f148f

namespace BookStore.Entities.Models
{
    public class Category
    {
        public int ID { get; set; }
        public String Name { get; set; }
        
        public virtual ICollection<BookCategory> BookCategories { get; set; }

        public static List<string> DefaultCategories = new List<string>
        {
            "Dramat",
            "Akcja",
            "Science Fiction",
            "Fantastyka",
            "Horror",
            "Historyczny",
            "Poemat"
        }; 
    }
}
