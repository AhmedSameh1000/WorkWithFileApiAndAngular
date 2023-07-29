using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace ZwajApp.api.Models
{
    public class User : IdentityUser
    {
        [Required]
        public string? Name { get; set; }

        public string? Gender { get; set; }

        public DateTime? DataOfBirth { get; set; }

        public string? KnownAS { get; set; }

        public DateTime? Created { get; set; }

        public DateTime? LastActive { get; set; }

        public string? Introduction { get; set; }

        public string? LookingFor { get; set; }
        public string? Interestes { get; set; }

        public string? City { get; set; }
        public string? Country { get; set; }
        public ICollection<Photo>? Photos { get; set; }
    }
}