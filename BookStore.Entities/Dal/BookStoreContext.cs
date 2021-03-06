﻿using System;
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
            : base()
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
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified))
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
            if (modelBuilder == null)
                throw new ArgumentNullException("modelBuilder");

            modelBuilder.Entity<User>()
                .HasMany(arg => arg.Roles)
                .WithRequired()
                .HasForeignKey(arg => arg.UserId);

            modelBuilder.Entity<User>()
                .Property(arg => arg.UserName)
                .IsRequired();

            modelBuilder.Entity<IdentityUserRole>()
                .HasKey(bc => new {bc.UserId, bc.RoleId})
                .ToTable("UserRoles");

            modelBuilder.Entity<IdentityUserLogin>()
                .HasKey(arg => new
                {
                    arg.UserId,
                    arg.LoginProvider,
                    arg.ProviderKey
                })
                .ToTable("UserLogins");

            modelBuilder.Entity<IdentityRole>()
                .ToTable("Roles");
            
            modelBuilder.Entity<Role>()
                .ToTable("Roles")
                .Property(arg => arg.Name).IsRequired();

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