namespace BookStore.Entities.Models
{
    public class User : ChangeBase
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int RoleId { get; set; }

        public virtual Role Role { get; set; }

    }
}
