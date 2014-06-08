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
            var att = GetAttachmentImpl(id);
            return att == null ? null : AttachmentModel.Create(att);
        }

        private Attachment GetAttachmentImpl(int id)
        {
            return _db.Attachments.Find(id);
        }

        public List<AttachmentModel> GetAttachments()
        {
            return _db.Attachments
                .OrderBy(arg => arg.Id)
                .AsEnumerable()
                .Select(AttachmentModel.Create)
                .ToList();
        }

        public List<AttachmentModel> GetAttachments(int bookId)
        {
            return _db.Attachments
                .OrderBy(arg => arg.Id)
                .Where(att => att.BookId == bookId)
                .AsEnumerable()
                .Select(AttachmentModel.Create)
                .ToList();
        }

        public bool AddAttachment(AttachmentModel attachment)
        {
            //Przerywamy jeżeli załącznik z takim id już istnieje
            if (AttachmentExists(attachment.Id))
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

        public void AddAttachments(IEnumerable<AttachmentModel> attachments)
        {
            foreach (var attachment in attachments)
            {
                //Sprawdzamy czy książka istnieje i czy nie ma takiego załącznika w bazie
                if (_db.Books.Find(attachment.BookId) != null && !AttachmentExists(attachment.Id))
                    _db.Attachments.Add(new Attachment
                    {
                        BookId = attachment.BookId,
                        Name = attachment.Name,
                        Content = attachment.Content
                    });    
            }
            _db.SaveChanges();
        }

        public bool DeleteAttachment(int id)
        {
            var attachment = GetAttachmentImpl(id);
            if (attachment == null)
                return false;
            _db.Attachments.Remove(attachment);
            _db.SaveChanges();
            return true;
        }

        public void DeleteAttachments(IEnumerable<int> ids)
        {
            foreach (var id in ids)
            {
                var attachment = GetAttachmentImpl(id);
                if (attachment != null)
                    _db.Attachments.Remove(attachment);
            }
            _db.SaveChanges();
        }

        public void AddDeleteAttachments(IEnumerable<AttachmentModel> attachments)
        {
            var attList = attachments.ToArray();
            var attIds = attList.Select(arg => arg.Id).ToArray();
            var attGroups = attList.GroupBy(arg => arg.BookId);
            foreach (var attGroup in attGroups)
            {
                var bookId = attGroup.Key;
                var toDelete = _db.Attachments
                    .Where(arg => arg.BookId == bookId)
                    .Select(arg => arg.Id)
                    .Except(attIds)
                    .Distinct();
                DeleteAttachments(toDelete);
            }
            //Dodajemy załączniki
            AddAttachments(attList);
        }

        public void ClearAttachments(int bookId)
        {
            var currentAtt = _db.Attachments.Where(arg => arg.BookId == bookId);
            _db.Attachments.RemoveRange(currentAtt);
            _db.SaveChanges();
        }

        public bool UpdateAttachment(AttachmentModel attachment)
        {
            var att = GetAttachmentImpl(attachment.Id);
            if (att == null)
                return false;
            att.BookId = attachment.BookId;
            att.Name = attachment.Name;
            att.Content = attachment.Content;
            _db.SaveChanges();
            return true;
        }

        public bool AttachmentExists(int id)
        {
            return _db.Attachments.Find(id) != null;
        }
    }
}