using BookStore.Entities.Models;

namespace BookStore.Logic.Repository
{
    public partial class Repository
    {
        public Attachment GetAttachmentById(int id)
        {
            return _db.Attachments.Find(id);
        }
        public bool AddAttachment(Attachment a)
        {
            if (_db.Attachments.Find(a.Id) != null)
            {
                return false;
            }
            _db.Attachments.Add(a);
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
