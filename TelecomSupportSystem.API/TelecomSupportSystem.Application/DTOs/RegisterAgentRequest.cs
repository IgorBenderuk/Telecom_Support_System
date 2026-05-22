using System.ComponentModel.DataAnnotations;

namespace TelecomSupportSystem.Application.DTOs
{
    public class RegisterAgentRequest
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
        //DOTO: delete password prop (for agent initially password will be tamporrar until agent will reset it by email)
        //the temporar ppassword should be generated authomatically
    }
}
