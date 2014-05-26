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

            //Dodajemy kategorie dla ksiazki
            books.ForEach(b =>
            {
                context.BookCategories.Add(new BookCategory {BookId = b.Id, CategoryId = 1});
                context.BookCategories.Add(new BookCategory {BookId = b.Id, CategoryId = 2});
                context.BookCategories.Add(new BookCategory {BookId = b.Id, CategoryId = 3});
            });
            context.SaveChanges();

            //Dodajemy domyślne zamówienia
            CreateDefaultOrders().ForEach(order => context.Orders.Add(order));
            context.SaveChanges();
        }

        private static List<Order> CreateDefaultOrders()
        {
            return new List<Order>
            {
                new Order
                {
                    BookId = 1,
                    UserId = 2,
                    Status = OrderStatus.Ordered
                },
                new Order
                {
                    BookId = 2,
                    UserId = 2,
                    Status = OrderStatus.Ready
                },
                new Order
                {
                    BookId = 1,
                    UserId = 1,
                    Status = OrderStatus.Canceled,
                    ShopComment = "Bo tak"
                },
                new Order
                {
                    BookId = 3,
                    UserId = 2,
                    Status = OrderStatus.Executed
                }
            };
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
                    Isbn = "1111111111111"
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
                    Isbn = "2222222222222"
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
                    Isbn = "3333333333333"
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
