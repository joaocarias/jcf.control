namespace Jcf.Control.Api.Applications.AuthenticationApp.Models.DTOs
{
    public class LoginDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public LoginDTO()
        {
            Email = string.Empty;
            Password = string.Empty;
        }

        public LoginDTO(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public bool IsValidate()
        {
            if (string.IsNullOrEmpty(Email) && string.IsNullOrEmpty(Password))
            {
                throw new ArgumentNullException($"{nameof(Email)} and {nameof(Password)} cannot be null or empty");
            }

            return true;
        }
    }
}
