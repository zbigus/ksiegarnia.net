using BookStore.Entities.Models;

namespace BookStore.Logic.Models
{
    public class AttachmentModel
    {
        public AttachmentModel(Attachment attachment)
        {
            Id = attachment.Id;
            BookId = attachment.BookId;
            Content = attachment.Content;
            Name = attachment.Name;
        }

        public int Id { get; set; }
        public int BookId { get; set; }
        public string Name { get; set; }
        public byte[] Content { get; set; }

        public static AttachmentModel Create(Attachment attachment)
        {
            return new AttachmentModel(attachment);
        }
    }
}