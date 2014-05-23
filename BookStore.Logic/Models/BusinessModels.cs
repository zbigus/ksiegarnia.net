using BookStore.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Logic.Models
{
        public class AttachmentModel
        {
            public int ID { get; set; }
            public int BookID { get; set; }
            public byte[] Content { get; set; }
        }

        public class SampleBookModel
        {
            //public int ID { get; set; }
            public string Title { get; set; }
            public string Author { get; set; }
            public int Price { get; set; }

        }

        public class BookModel:SampleBookModel
            {
            //TODO: Dodać walidację, tylko 13 cyfr
            public string ISBN { get; set; }
            public string Publisher { get; set; }
            public DateTime Year { get; set; }
            public string Description { get; set; }
            }
        public class UserModel
        {
            public int ID { get; set; }
            public string Login { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Address { get; set; }
            public int RoleID { get; set; }
            public Role Role { get; set; }
        }
        public class RoleModel
        {
            public int ID { get; set; }
            public string Name { get; set; }
        }
        public class OrderModel
        {
            public int ID { get; set; }
            public int BookID { get; set; }
            public int UserID { get; set; }
            public string ShopComment { get; set; }
            public OrderStatus Status { get; set; }
        }
        public class CategoryModel
        {
            public int ID { get; set; }
            public String Name { get; set; }
        }
        public class BookCategory
        {
            public int BookID { get; set; }
            public int CategoryID { get; set; }
        }
    
}
