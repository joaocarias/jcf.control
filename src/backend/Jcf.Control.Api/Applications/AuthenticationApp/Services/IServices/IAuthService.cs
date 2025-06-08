using Jcf.Control.Api.Applications.UserApp.Entities;

namespace Jcf.Control.Api.Applications.AuthenticationApp.Services.IServices
{
    public interface IAuthService
    {
        Task<User?> AuthenticateAsync(string userName, string password);
    }
}
