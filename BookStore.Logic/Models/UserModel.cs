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
        //TODO: Tu masz referencj� do Entity, nie lepiej by�o by zamieni� to na RoleModel? Tak z ciekawo�ci to po co jest ta referencja?
        public Role Role { get; set; }
    }
}