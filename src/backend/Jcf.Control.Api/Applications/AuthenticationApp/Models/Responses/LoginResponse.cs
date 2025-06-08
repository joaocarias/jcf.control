using Jcf.Control.Api.Applications.UserApp.Models.DTOs;

namespace Jcf.Control.Api.Applications.AuthenticationApp.Models.Responses
{
    public class LoginResponse
    {
        public bool IsAuth = false;
        public UserDTO? User { get; set; }
        public string? Token { get; set; }
        public string? Message { get; set; }

        public LoginResponse(bool isAuth, UserDTO user, string token, string message)
        {
            User = user;
            Token = token;
            IsAuth = isAuth;
            Message = message;
        }

        public LoginResponse() { }
    }
}
