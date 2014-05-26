using System;
using BookStore.Entities.Dal;
using BookStore.Logic.Interfaces;

namespace BookStore.Logic.Repository
{
    public partial class Repository : IDisposable, IRepository
    {
        private BookStoreContext _db = new BookStoreContext();

        protected void Dispose(bool disposing)
        {
            if (!disposing || _db == null) return;
            _db.Dispose();
            _db = null;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
