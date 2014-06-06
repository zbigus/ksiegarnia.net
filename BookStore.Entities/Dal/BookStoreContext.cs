using System;
using System.Data.Entity;
using System.Linq;
using BookStore.Entities.Managers;
using BookStore.Entities.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BookStore.Entities.Dal
{
    public class BookStoreContext : IdentityDbContext<User>
    {
        public BookStoreContext()
            : base(ConnectionStringManager.Current)
        {
        }

        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<BookCategory> BookCategories { get; set; }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries<ChangeBase>()
                .Where(e => e.State == EntityState.Added && e.State == EntityState.Modified))
            {
                DateTime now = DateTime.Now;
                if (entry.State == EntityState.Added)
                    entry.Entity.InsertDate = now;
                entry.Entity.ModificationDate = now;
            }
            return base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserRole>()
                .HasKey(bc => new {bc.RoleId, bc.UserId});

            modelBuilder.Entity<User>()
                .HasMany(arg => arg.Roles)
                .WithRequired()
                .HasForeignKey(arg => arg.UserId);

            modelBuilder.Entity<IdentityUserLogin>()
                .HasKey(arg => arg.UserId);

            modelBuilder.Entity<BookCategory>()
                .HasKey(bc => new {bc.BookId, bc.CategoryId});

            modelBuilder.Entity<Book>()
                .HasMany(b => b.BookCategories)
                .WithRequired()
                .HasForeignKey(bc => bc.BookId);

            modelBuilder.Entity<Category>()
                .HasMany(c => c.BookCategories)
                .WithRequired()
                .HasForeignKey(bc => bc.CategoryId);
        }

        public static BookStoreContext Create()
        {
            return new BookStoreContext();
        }
    }
}