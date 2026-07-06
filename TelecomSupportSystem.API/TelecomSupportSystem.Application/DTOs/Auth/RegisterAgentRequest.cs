using System.ComponentModel.DataAnnotations;

namespace TelecomSupportSystem.Application.DTOs.Auth
{
    public record RegisterAgentRequest(
    [Required][EmailAddress] string Email,
    [Required] string FirstName,
    [Required] string LastName,
    [Required][MinLength(8)] string Password
    );
    //TODO: delete password prop (for agent initially password will be tamporrar until agent will reset it by email)
    //the temporar ppassword should be generated authomatically
}
