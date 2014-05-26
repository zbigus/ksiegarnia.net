using System.Runtime.Serialization;
using BookStore.Entities.Models;

namespace BookStore.Logic.Models
{
    [DataContract]
    public class UserModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Login { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Address { get; set; }
        //TODO: do poprawy
        [DataMember]
        public string Role { get; set; }

        public static UserModel Create(User user)
        {
            return new UserModel
            {
                Id = user.Id,
                Login = user.Login,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Address = user.Address,
                Role = user.Role.Name
            };
        }
    }
}