namespace Jcf.Control.Api.Applications.UserApp.Controllers
{
    internal class LoginResponseDTO
    {
        public LoginResponseDTO()
        {
        }

        public object? Result { get; set; } 
        public string Token { get; set; } = string.Empty;
        public bool IsSuccess { get; set; } = true;
    }
}