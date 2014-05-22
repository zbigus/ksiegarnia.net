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
            var roles = new List<Role>
            {
                new Role {ID = 1, Name = "Admin"},
                new Role {ID = 2, Name = "User"}
            };
            roles.ForEach(r => context.Roles.Add(r));
            context.SaveChanges();

            //Dodajemy domyślnych userów tylko dla testów
            var users = new List<User>
            {
                new User
                {
                    Login = "Admin",
                    FirstName = "Admin",
                    LastName = "Admin",
                    Email = "Admin@Admin.com",
                    Address = "Ulica świętego Admina",
                    RoleID = 1,
                    Password = Md5Helper.CreateMd5Hash("Admin")
                },
                new User
                {
                    Login = "User",
                    FirstName = "User",
                    LastName = "User",
                    Email = "User@Admin.com",
                    Address = "Ulica świętego Usera",
                    RoleID = 2,
                    Password = Md5Helper.CreateMd5Hash("User")
                }
            };
            users.ForEach(u => context.Users.Add(u));
            context.SaveChanges();

            //Dodajemy testowe ksiązki
            var books = new List<Book>
            {
                new Book
                {
                    ID = 1,
                    Author = "Rączka",
                    Description = "Nauki doktora rączki część 1.",
                    Title = ".Net part 1",
                    Year = DateTime.Now,
                    Price = 0,
                    Publisher = "Rączka",
                    ISBN = "1111111111111"
                },
                new Book
                {
                    ID = 2,
                    Author = "Rączka",
                    Description = "Nauki doktora rączki część 2.",
                    Title = ".Net part 2",
                    Year = DateTime.Now,
                    Price = 0,
                    Publisher = "Rączka",
                    ISBN = "2222222222222"
                },
                new Book
                {
                    ID = 3,
                    Author = "Rączka",
                    Description = "Nauki doktora rączki część 3.",
                    Title = ".Net part 3",
                    Year = DateTime.Now,
                    Price = 0,
                    Publisher = "Rączka",
                    ISBN = "3333333333333"
                },
                new Book
                {
                    ID = 4,
                    Author = "Rączka",
                    Description = "Nauki doktora rączki część 4.",
                    Title = ".Net part 4",
                    Year = DateTime.Now,
                    Price = 0,
                    Publisher = "Rączka",
                    ISBN = "4444444444444"
                },
            };
            books.ForEach(b => context.Books.Add(b));
            context.SaveChanges();

            //Dodajemy domyslne kategorie
            Category.DefaultCategories.ForEach(def => context.Categories.Add(new Category {Name = def}));
            context.SaveChanges();

            //Dodajemy jedna kategorie dla ksiazki
            books.ForEach(b => context.BookCategories.Add(new BookCategory {BookID = b.ID, CategoryID = 1}));
            context.SaveChanges();
        }
    }
}
