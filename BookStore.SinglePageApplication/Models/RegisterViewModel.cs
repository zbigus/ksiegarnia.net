using System.ComponentModel.DataAnnotations;
using BookStore.Entities.Models;

namespace BookStore.SinglePageApplication.Models
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Nazwa u�ytkownika")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} musi zawiera� co najmniej {2} znak�w.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Has�o")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Potwierd� has�o")]
        [Compare("Password", ErrorMessage = "Has�o i jego potwierdzenie nie pasuj� do siebie, sorry.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "{0} nie mo�e zawiera� wi�cej ni� {1} znak�w.")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "{0} nie mo�e zawiera� wi�cej ni� {1} znak�w.")]
        public string LastName { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "{0} nie mo�e zawiera� wi�cej ni� {1} znak�w.")]
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