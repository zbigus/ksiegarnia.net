using BookStore.Entities.Helpers;
using BookStore.Entities.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace BookStore.Entities.Dal
{
    public class BookStoreInitializer : DropCreateDatabaseIfModelChanges<BookStoreContext>
    {
        protected override void Seed(BookStoreContext context)
        {
            //Dodajemy role
            CreateDefaultRoles().ForEach(r => context.Roles.Add(r));
            context.SaveChanges();

            //Dodajemy domyślnych userów tylko dla testów
            CreateDefaultUsers().ForEach(u => context.Users.Add(u));
            context.SaveChanges();

            //Dodajemy testowe ksiązki
            var books = CreateDefaultBooks();
            books.ForEach(b => context.Books.Add(b));
            context.SaveChanges();

            //Dodajemy domyslne kategorie
            Category.DefaultCategories.ForEach(def => context.Categories.Add(new Category {Name = def}));
            context.SaveChanges();

            //Dodajemy jedna kategorie dla ksiazki
            books.ForEach(b => context.BookCategories.Add(new BookCategory {BookId = b.Id, CategoryId = 1}));
            context.SaveChanges();
        }

        private static List<Book> CreateDefaultBooks()
        {
            return new List<Book>
            {
                new Book
                {
                    Id = 1,
                    Author = "Rączka",
                    Description = "Nauki doktora rączki część 1.",
                    Title = ".Net part 1",
                    Year = DateTime.Now,
                    Price = 0,
                    Publisher = "Rączka",
                    Isbn = "1111111111111",
                    InsertDate = DateTime.Now,
                    ModificationDate = DateTime.Now
                },
                new Book
                {
                    Id = 2,
                    Author = "Rączka",
                    Description = "Nauki doktora rączki część 2.",
                    Title = ".Net part 2",
                    Year = DateTime.Now,
                    Price = 0,
                    Publisher = "Rączka",
                    Isbn = "2222222222222",
                    InsertDate = DateTime.Now,
                    ModificationDate = DateTime.Now
                },
                new Book
                {
                    Id = 3,
                    Author = "Rączka",
                    Description = "Nauki doktora rączki część 3.",
                    Title = ".Net part 3",
                    Year = DateTime.Now,
                    Price = 0,
                    Publisher = "Rączka",
                    Isbn = "3333333333333",
                    InsertDate = DateTime.Now,
                    ModificationDate = DateTime.Now
                },
                new Book
                {
                    Id = 4,
                    Author = "Rączka",
                    Description = "Nauki doktora rączki część 4.",
                    Title = ".Net part 4",
                    Year = DateTime.Now,
                    Price = 0,
                    Publisher = "Rączka",
                    Isbn = "4444444444444",
                    InsertDate = DateTime.Now,
                    ModificationDate = DateTime.Now
                },
            };
        }

        private static List<User> CreateDefaultUsers()
        {
            return new List<User>
            {
                new User
                {
                    Login = "Admin",
                    FirstName = "Admin",
                    LastName = "Admin",
                    Email = "Admin@Admin.com",
                    Address = "Ulica świętego Admina",
                    RoleId = 1,
                    Password = Md5Helper.CreateMd5Hash("Admin"),
                    InsertDate = DateTime.Now,
                    ModificationDate = DateTime.Now
                },
                new User
                {
                    Login = "User",
                    FirstName = "User",
                    LastName = "User",
                    Email = "User@Admin.com",
                    Address = "Ulica świętego Usera",
                    RoleId = 2,
                    Password = Md5Helper.CreateMd5Hash("User"),
                    InsertDate = DateTime.Now,
                    ModificationDate = DateTime.Now
                }
            };
        }

        private static List<Role> CreateDefaultRoles()
        {
            return new List<Role>
            {
                new Role {Id = 1, Name = "Admin"},
                new Role {Id = 2, Name = "User"}
            };
        }
    }
}
