using System;
using System.Data.Entity;
using System.Linq;
using BookStore.Entities.Models;
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
        public DbSet<BookCategory> BookCategories { get; set; }

        public BookStoreContext()
            : base(ConnectionStringManager.Current)
        {
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries<ChangeBase>()
                        .Where(e => e.State == EntityState.Added && e.State == EntityState.Modified))
            {
                var now = DateTime.Now;
                if (entry.State == EntityState.Added)
                    entry.Entity.InsertDate = now;
                entry.Entity.ModificationDate = now;

            }
            return base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookCategory>()
               .HasKey(bc => new {bc.BookId, bc.CategoryId });

            modelBuilder.Entity<Book>()
                        .HasMany(b => b.BookCategories)
                        .WithRequired()
                        .HasForeignKey(bc => bc.BookId);

            modelBuilder.Entity<Category>()
                        .HasMany(c => c.BookCategories)
                        .WithRequired()
                        .HasForeignKey(bc => bc.CategoryId); 
        }
    }
}
