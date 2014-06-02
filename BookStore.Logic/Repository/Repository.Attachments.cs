using System.Collections.Generic;
using System.Linq;
using BookStore.Entities.Models;
using BookStore.Logic.Models;

namespace BookStore.Logic.Repository
{
    public partial class Repository
    {
        public AttachmentModel GetAttachment(int id)
        {
            var att = _db.Attachments.Find(id);
            return att == null ? null : AttachmentModel.Create(att);
        }

        public List<AttachmentModel> GetAttachments(int bookId)
        {
            return _db.Attachments.Where(att => att.BookId == bookId).Select(AttachmentModel.Create).ToList();
        }

        public bool AddAttachment(AttachmentModel attachment)
        {
            //Przerywamy jeżeli załącznik z taką nazwą już istnieje
            if (_db.Attachments.Find(attachment.Id) != null)
                return false;
            //Nie dodajemy załączników bez istniejącej książki
            if (_db.Books.Find(attachment.BookId) == null)
                return false;
            _db.Attachments.Add(new Attachment
            {
                BookId = attachment.BookId,
                Name = attachment.Name,
                Content = attachment.Content
            });
            _db.SaveChanges();
            return true;
        }

        public bool DeleteAttachment(int id)
        {
            var attachment = _db.Attachments.Find(id);
            if (attachment == null)
                return false;
            _db.Attachments.Remove(attachment);
            _db.SaveChanges();
            return true;
        }
    }
}
