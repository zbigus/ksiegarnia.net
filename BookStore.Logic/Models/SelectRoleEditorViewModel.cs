using System.ComponentModel.DataAnnotations;

namespace BookStore.Logic.Models
{
    public class SelectRoleEditorViewModel
    {
        public bool Selected { get; set; }

        [Required]
        public string RoleName { get; set; }
    }
}