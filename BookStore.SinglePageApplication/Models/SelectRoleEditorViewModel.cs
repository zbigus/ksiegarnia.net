using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BookStore.SinglePageApplication.Models
{
    public class SelectRoleEditorViewModel
    {
        public bool Selected { get; set; }

        [Required]
        public string RoleName { get; set; }
    }
}