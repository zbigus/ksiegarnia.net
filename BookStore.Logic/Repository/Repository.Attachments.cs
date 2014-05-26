using BookStore.Entities.Models;
using System.Collections.Generic;
using System.Linq;
using BookStore.Logic.Models;

namespace BookStore.Logic.Repository
{
    public partial class Repository
    {
        public IEnumerable<AttachmentModel> GetAttachments()
        {
            return _db.Attachments.Select(attachment => AttachmentModel.Create(attachment))
                .ToList();
        }

        public IEnumerable<AttachmentModel> GetAttachments(int bookId)
        {
            return _db.Attachments.Where(att => att.BookId == bookId)
                .Select(attachment => AttachmentModel.Create(attachment))
                .ToList();
        }

        public AttachmentModel GetAttachment(int attachmentId)
        {
            var attachment = _db.Attachments.Find(attachmentId);
            return attachment == null ? null : AttachmentModel.Create(attachment);
        }

        public bool AddAttachment(AttachmentModel attachment)
        {
            if (_db.Attachments.Find(attachment.Id) != null)
                return false;
            _db.Attachments.Add(new Attachment
            {
                Name = attachment.Name,
                Content = attachment.Content,
                BookId = attachment.BookId
            });
            _db.SaveChanges();
            return true;
        }

        public bool DeleteAttachment(int id)
        {
            var attachment = _db.Attachments.Find(id);
            if (attachment == null)
            {
                return false;
            }
            _db.Attachments.Remove(attachment);
            _db.SaveChanges();
            return true;
        }
    }
}
