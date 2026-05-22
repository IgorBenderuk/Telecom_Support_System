using System.ComponentModel.DataAnnotations;

namespace TelecomSupportSystem.Application.DTOs
{

    public record RegisterCustomerRequest(
     [Required][EmailAddress] string Email,
     [Required] string FirstName,
     [Required] string LastName,
     [Required][MinLength(8)] string Password
 );
}
