﻿using System.Data.Entity;
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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookCategory>()
               .HasKey(bc => new { bc.BookID, bc.CategoryID });

            modelBuilder.Entity<Book>()
                        .HasMany(b => b.BookCategories)
                        .WithRequired()
                        .HasForeignKey(bc => bc.BookID);

            modelBuilder.Entity<Category>()
                        .HasMany(c => c.BookCategories)
                        .WithRequired()
                        .HasForeignKey(bc => bc.CategoryID); 
        }
    }
}
