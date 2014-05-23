using System;

namespace BookStore.Entities.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int RoleID { get; set; }

        public DateTime? InsertDate { get; set; }
        public DateTime? ModificationDate { get; set; }

        public virtual Role Role { get; set; }
    }
}
