using System.ComponentModel.DataAnnotations;
using BookStore.Entities.Models;

namespace BookStore.SinglePageApplication.Models
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Nazwa u¿ytkownika")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} musi zawieraæ co najmniej {2} znaków.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Has³o")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "PotwierdŸ has³o")]
        [Compare("Password", ErrorMessage = "Has³o i jego potwierdzenie nie pasuj¹ do siebie, sorry.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "{0} nie mo¿e zawieraæ wiêcej ni¿ {1} znaków.")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "{0} nie mo¿e zawieraæ wiêcej ni¿ {1} znaków.")]
        public string LastName { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "{0} nie mo¿e zawieraæ wiêcej ni¿ {1} znaków.")]
        public string Address { get; set; }

        public User GetUser()
        {
            return new User
            {
                UserName = UserName,
                Email = Email,
                FirstName = FirstName,
                LastName = LastName,
                Address = Address
            };
        }
    }
}