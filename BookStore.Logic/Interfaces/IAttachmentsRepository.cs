using System.Collections.Generic;
using BookStore.Logic.Models;

namespace BookStore.Logic.Interfaces
{
    public interface IAttachmentsRepository
    {
        IEnumerable<AttachmentModel> GetAttachments();
        IEnumerable<AttachmentModel> GetAttachments(int bookId);
        AttachmentModel GetAttachment(int attachmentId);
        bool AddAttachment(AttachmentModel attachment);
        bool DeleteAttachment(int id);
    }
}
