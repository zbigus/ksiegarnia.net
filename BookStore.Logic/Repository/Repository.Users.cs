﻿using BookStore.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Logic.Repository
{
    public partial class Repository : IDisposable
    {
        public IQueryable<User> GetAllUsers()
        {
            return _db.Users.AsQueryable();
        }
        public IQueryable<User> GetUsersByRole(string role)
        {
            return _db.Users.Where(s => s.Role.Name.Equals(role, StringComparison.OrdinalIgnoreCase));
        }
        public bool AddUser(User user)
        {
            if (_db.Users.Find(user.Id) != null)
            {
                return false;
            }
            _db.Users.Add(user);
            _db.SaveChanges();
            return true;
        }
        protected void Dispose(bool disposing)
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

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}