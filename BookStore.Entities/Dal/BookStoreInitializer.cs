using BookStore.Entities.Managers;
using BookStore.Entities.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using Microsoft.AspNet.Identity;

namespace BookStore.Entities.Dal
{
    public class BookStoreInitializer : DropCreateDatabaseIfModelChanges<BookStoreContext>
    {
        protected override void Seed(BookStoreContext context)
        {
            //Dodajemy role
            CreateDefaultRoles(context);
            CreateAdmin(context);
            
            //Dodajemy domyślnych userów tylko dla testów
            CreateDefaultUsers(5, context);
            
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

            //Dodajemy domyślne zamówienia
            CreateDefaultOrders().ForEach(order => context.Orders.Add(order));
            context.SaveChanges();
        }

        private static void CreateDefaultRoles(BookStoreContext context)
        {
            var manager = new IdentityManager(context);
            manager.CreateRole(Role.Admin);
            manager.CreateRole(Role.User);
        }

        private static void CreateAdmin(BookStoreContext context)
        {
            var manager = new IdentityManager(context);
            var user = new User
            {
                Address = "Kraków ul.Pychowicka 18/55",
                Email = "admin@bookstore.com",
                FirstName = "Admin",
                LastName = "Admin",
                UserName = "Admin"
            };
            manager.CreateUser(user, "Zxasqw!2");
            manager.AddUserToRole(user.Id, Role.Admin);
        }

        private static void CreateDefaultUsers(int count, BookStoreContext context)
        {
            var manager = new IdentityManager(context);
            for (var i = 0; i < count; i++)
            {
                var user = new User
                {
                    Address = "Kraków ul.Pychowicka 18/55",
                    Email = string.Format("user{0}@bookstore.com", i),
                    FirstName = string.Format("User{0}FirstName", i),
                    LastName = string.Format("User{0}LastName", i),
                    UserName = string.Format("User{0}", i)
                };
                manager.CreateUser(user, string.Format("Zxasqw!2{0}", i));
                manager.AddUserToRole(user.Id, Role.User);
            }
        }

        private static List<Order> CreateDefaultOrders()
        {
            return new List<Order>
            {
                new Order {BookId = 1, 
                    //UserId = 1, 
                    Status = OrderStatus.Ordered},
                new Order {BookId = 2, 
                    //UserId = 2, 
                    Status = OrderStatus.Canceled, ShopComment = "Brak w magazynie"},
                new Order {BookId = 3, 
                    //UserId = 1, 
                    Status = OrderStatus.Ready},
                new Order {BookId = 4, 
                    //UserId = 2, 
                    Status = OrderStatus.Canceled},
                new Order {BookId = 1, 
                    //UserId = 2, 
                    Status = OrderStatus.Canceled},
                new Order {BookId = 2, 
                    //UserId = 1, 
                    Status = OrderStatus.Executed},
                new Order {BookId = 3, 
                    //UserId = 2, 
                    Status = OrderStatus.Ordered},
                new Order {BookId = 4, 
                    //UserId = 1, 
                    Status = OrderStatus.Ordered}
            };
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
