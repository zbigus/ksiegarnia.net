using System.Data.Entity;
using BookStore.Entities.Models;
using System.Diagnostics;
using BookStore.Entities.Managers;

namespace BookStore.Entities.Dal
{
    public class BookStoreContext : DbContext
    {
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        public BookStoreContext()
            : base(ConnectionStringManager.Current)
        {
            Debug.Write(Database.Connection.ConnectionString);
        }
    }
}
