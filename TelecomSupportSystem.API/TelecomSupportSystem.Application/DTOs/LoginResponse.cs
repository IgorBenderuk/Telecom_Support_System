namespace TelecomSupportSystem.Application.DTOs
{
    public class LoginResponse(string AccessToken)
    {
        public string AccessToken { get; set; } = AccessToken;
    }
}
