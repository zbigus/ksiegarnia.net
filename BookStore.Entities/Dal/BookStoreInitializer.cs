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
            CreateDefaultCategories().ForEach(category => context.Categories.Add(category));
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
                    Author = "Stephenie Meyer",
                    Description = "Zmierzch",
                    Title = "Zmierzch",
                    Year = DateTime.Now,
                    Price = 40,
                    Publisher = "Ja",
                    Isbn = "1111111111111"
                },
                new Book
                {
                    Id = 2,
                    Author = "Stephenie Meyer",
                    Description = "Księżyc w nowiu",
                    Title = "Księżyc w nowiu",
                    Year = DateTime.Now,
                    Price = 30,
                    Publisher = "JA",
                    Isbn = "2222222222222"
                },
                new Book
                {
                    Id = 3,
                    Author = "Stephenie Meyer",
                    Description = "Zaćmienie",
                    Title = "Zaćmienie",
                    Year = DateTime.Now,
                    Price = 50,
                    Publisher = "Ja",
                    Isbn = "3333333333333"
                },
                new Book
                {
                    Id = 4,
                    Author = "Stephenie Meyer",
                    Description = "Przed świtem",
                    Title = "Przed świtem",
                    Year = DateTime.Now,
                    Price = 0,
                    Publisher = "Ja",
                    Isbn = "4444444444444"
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
                    Password = Md5Helper.CreateMd5Hash("Admin")
                },
                new User
                {
                    Login = "User",
                    FirstName = "User",
                    LastName = "User",
                    Email = "User@Admin.com",
                    Address = "Ulica świętego Usera",
                    RoleId = 2,
                    Password = Md5Helper.CreateMd5Hash("User")
                }
            };
        }

        private static List<Role> CreateDefaultRoles()
        {
            return new List<Role>
            {
                new Role {Id = 1, Name = Role.Admin},
                new Role {Id = 2, Name = Role.User}
            };
        }

        public static List<Category> CreateDefaultCategories()
        {
            return new List<Category>
            {
                new Category {Name = "Dramat"},
                new Category {Name = "Akcja"},
                new Category {Name = "Science Fiction"},
                new Category {Name = "Fantastyka"},
                new Category {Name = "Horror"},
                new Category {Name = "Historyczny"},
                new Category {Name = "Poemat"}
            };
        }  
    }
}
