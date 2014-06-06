using System.ComponentModel.DataAnnotations;
using BookStore.Entities.Models;

namespace BookStore.SinglePageApplication.Models
{
    public class EditUserViewModel
    {
        public EditUserViewModel()
        {
        }

        public EditUserViewModel(User user)
        {
            UserName = user.UserName;
            Email = user.Email;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Address = user.Address;
        }

        [Required]
        [Display(Name = "Nazwa użytkownika")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "{0} nie może zawierać więcej niż {1} znaków.")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "{0} nie może zawierać więcej niż {1} znaków.")]
        public string LastName { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "{0} nie może zawierać więcej niż {1} znaków.")]
        public string Address { get; set; }

    }
}