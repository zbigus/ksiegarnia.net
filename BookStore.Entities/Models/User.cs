using System;
<<<<<<< HEAD
using System.Collections.Generic;
using System.Runtime.Serialization;
=======
>>>>>>> 904c21be24cf3fe30bbe7be1c2a6c1da5d4f148f

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

<<<<<<< HEAD
        public Role Role { get; set; }
=======
        public DateTime? InsertDate { get; set; }
        public DateTime? ModificationDate { get; set; }

        public virtual Role Role { get; set; }
>>>>>>> 904c21be24cf3fe30bbe7be1c2a6c1da5d4f148f
    }
}
