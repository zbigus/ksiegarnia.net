using BookStore.Entities.Models;

namespace BookStore.Logic.Interfaces
{
    public interface IAttachmentsRepository
    {
        Attachment GetAttachmentById(int id);
        bool AddAttachment(Attachment a);
        bool DeleteAttachment(int id);
    }
}
