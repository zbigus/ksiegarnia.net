namespace BookStore.Logic.Models
{
    public class AttachmentModel
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string Name { get; set; }
        public byte[] Content { get; set; }
    }
}
