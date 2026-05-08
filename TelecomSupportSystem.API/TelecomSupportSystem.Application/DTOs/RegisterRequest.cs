using System.ComponentModel.DataAnnotations;

namespace TelecomSupportSystem.Application.DTOs
{
    public class RegisterRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [MinLength(8)]
        public string Password { get; set; }
    }
}
