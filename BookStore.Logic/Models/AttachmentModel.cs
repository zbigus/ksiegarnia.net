using System.Runtime.Serialization;
using BookStore.Entities.Models;

namespace BookStore.Logic.Models
{
    [DataContract]
    public class AttachmentModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int BookId { get; set; }
        [DataMember]
        public byte[] Content { get; set; }
        [DataMember]
        public string Name { get; set; }

        public AttachmentModel(Attachment attachment)
        {
            Id = attachment.Id;
            BookId = attachment.BookId;
            Content = attachment.Content;
            Name = attachment.Name;
        }

        public static AttachmentModel Create(Attachment attachment)
        {
            return new AttachmentModel(attachment);
        }
    }
}
