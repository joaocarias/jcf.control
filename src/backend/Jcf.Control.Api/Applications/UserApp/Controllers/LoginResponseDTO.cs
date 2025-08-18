namespace Jcf.Control.Api.Applications.UserApp.Controllers
{
    internal class LoginResponseDTO
    {
        public LoginResponseDTO()
        {
        }

        public object? User { get; set; }
        public string Token { get; set; }
        public bool IsSuccess { get; set; } = true;
    }
}