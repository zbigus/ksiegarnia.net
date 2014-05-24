using BookStore.Entities.Models;

namespace BookStore.Logic.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int RoleId { get; set; }
        //TODO: Tu masz referencjê do Entity, nie lepiej by³o by zamieniæ to na RoleModel? Tak z ciekawoœci to po co jest ta referencja?
        public Role Role { get; set; }
    }
}