namespace BookStore.Entities.Models
{
    public class BookCategory
    {
        public int BookID { get; set; }
        public int CategoryID { get; set; }

        public virtual Book Book { get; set; }
        public virtual Category Category { get; set; }
    }
}
