using System.ComponentModel.DataAnnotations;

namespace TelecomSupportSystem.Application.DTOs
{
    public record LoginRequest
    (
    [Required][EmailAddress] string Email,
    [Required][MinLength(8)] string Password
    );
}
