using System.Collections.Generic;
using BookStore.Logic.Models;

namespace BookStore.Logic.Interfaces
{
    public interface IAttachmentsRepository
    {
        AttachmentModel GetAttachment(int id);
        bool AddAttachment(AttachmentModel attachment);
        bool DeleteAttachment(int id);
        List<AttachmentModel> GetAttachments(int bookId);
    }
}