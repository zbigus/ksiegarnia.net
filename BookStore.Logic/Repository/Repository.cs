﻿using System;
using BookStore.Entities.Dal;
using BookStore.Logic.Interfaces;

namespace BookStore.Logic.Repository
{
    public partial class Repository : IRepository, IDisposable
    {
        private BookStoreContext _db = new BookStoreContext();

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_db != null)
                {
                    _db.Dispose();
                    _db = null;
                }
            }
        }
    }
}