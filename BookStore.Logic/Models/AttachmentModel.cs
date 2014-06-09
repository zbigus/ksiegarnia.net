using System.ComponentModel.DataAnnotations;
using BookStore.Entities.Models;

namespace BookStore.Logic.Models
{
    public class AttachmentModel
    {
        public AttachmentModel()
        {
        }

        public AttachmentModel(Attachment attachment)
        {
            Id = attachment.Id;
            BookId = attachment.BookId;
            Content = attachment.Content;
            Name = attachment.Name;
        }

        public int Id { get; set; }
        public int BookId { get; set; }
        [Required]
        [StringLength(255, ErrorMessage = "{0} nie może zawierać więcej niż {1} znaków.")]
        public string Name { get; set; }
        [Required]
        public byte[] Content { get; set; }

        public static AttachmentModel Create(Attachment attachment)
        {
            return new AttachmentModel(attachment);
        }
    }
}