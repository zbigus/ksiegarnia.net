namespace BookStore.Entities.Models
{
    public class Attachment
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string Name { get; set; }
        public byte[] Content { get; set; }

        public virtual Book Book { get; set; }
    }
}