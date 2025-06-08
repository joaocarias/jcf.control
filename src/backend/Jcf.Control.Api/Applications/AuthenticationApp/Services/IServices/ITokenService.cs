using Jcf.Control.Api.Applications.UserApp.Entities;
using System.Security.Claims;

namespace Jcf.Control.Api.Applications.AuthenticationApp.Services.IServices
{
    public interface ITokenService
    {
        ClaimsIdentity GeneratorClaims(User user);
        string NewToken(User user);
    }
}
