namespace BookStore.Entities.Models
{
    public class Role
    {
        public const string Admin = "Admin";
        public const string User = "User";

        public int Id { get; set; }
        public string Name { get; set; }
    }
}