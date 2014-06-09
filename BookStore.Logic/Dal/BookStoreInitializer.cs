using System;
using System.Collections.Generic;
using System.Data.Entity;
using BookStore.Entities.Dal;
using BookStore.Entities.Models;
using BookStore.Logic.Extensions;
using BookStore.Logic.Managers;

namespace BookStore.Logic.Dal
{
    public class BookStoreInitializer : DropCreateDatabaseIfModelChanges<BookStoreContext>
    {
        protected override void Seed(BookStoreContext context)
        {
            //Dodajemy role
            CreateDefaultRoles(context);
            CreateAdmin(context);

            //Dodajemy domyślnych userów tylko dla testów
            var  users = CreateDefaultUsers(5, context);

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

            var att = ImageHelper.GetSimpleImage();
            books.ForEach(book => context.Attachments.Add(new Attachment() { BookId = book.Id, Name = "SimpleImage.jpg", Content = att}));
            context.SaveChanges();

            //Dodajemy domyślne zamówienia
            CreateDefaultOrders(users).ForEach(order => context.Orders.Add(order));
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

        private static List<User> CreateDefaultUsers(int count, BookStoreContext context)
        {
            var result = new List<User>();
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
                result.Add(user);
                manager.CreateUser(user, string.Format("Zxasqw!2{0}", i));
                manager.AddUserToRole(user.Id, Role.User);
            }
            return result;
        }

        private static List<Order> CreateDefaultOrders(IEnumerable<User> users)
        {
            var result = new List<Order>();
            foreach (var user in users)
            {
                result.Add(new Order
                {
                    BookId = 1, 
                    UserId = user.Id, 
                    Status = OrderStatus.Ordered
                });
                result.Add(new Order
                {
                    BookId = 2,
                    UserId = user.Id, 
                    Status = OrderStatus.Canceled,
                    ShopComment = "Brak w magazynie"
                });
                result.Add(new Order
                {
                    BookId = 3,
                    UserId = user.Id, 
                    Status = OrderStatus.Ready
                });
                result.Add(new Order
                {
                    BookId = 4,
                    UserId = user.Id, 
                    Status = OrderStatus.Canceled
                });
                result.Add(new Order
                {
                    BookId = 1,
                    UserId = user.Id, 
                    Status = OrderStatus.Canceled
                });
                result.Add(new Order
                {
                    BookId = 2,
                    UserId = user.Id, 
                    Status = OrderStatus.Executed
                });
                result.Add(new Order
                {
                    BookId = 3,
                    UserId = user.Id, 
                    Status = OrderStatus.Ordered
                });
                result.Add(new Order
                {
                    BookId = 4,
                    UserId = user.Id, 
                    Status = OrderStatus.Ordered
                });
            }
            return result;
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