using Jcf.Control.Api.Applications.AuthenticationApp.Services.IServices;
using Jcf.Control.Api.Applications.UserApp.Entities;
using Jcf.Control.Api.Applications.UserApp.Repositories.IRepositories;
using Jcf.Control.Api.Core.Uteis;

namespace Jcf.Control.Api.Applications.AuthenticationApp.Services
{
    public class AuthService : IAuthService
    {
        private readonly ILogger<AuthService> _logger;
        private readonly IUserRepository _userRepository;

        public AuthService(ILogger<AuthService> logger, IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        public async Task<User?> AuthenticateAsync(string userName, string password)
        {
            try
            {
                return await _userRepository.AuthenticateAsync(userName, PasswordUtil.CreateHashMD5(password));
            }
            catch (Exception ex)
            {
                _logger.LogError($"[{nameof(AuthService)} - {nameof(AuthenticateAsync)}] | {ex.Message}");
                return null;
            }
        }
    }
}
