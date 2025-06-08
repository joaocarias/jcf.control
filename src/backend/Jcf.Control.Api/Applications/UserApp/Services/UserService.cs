using Jcf.Control.Api.Applications.UserApp.Repositories.IRepositories;
using Jcf.Control.Api.Applications.UserApp.Services.IServices;
using Jcf.Control.Api.Core.Uteis;

namespace Jcf.Control.Api.Applications.UserApp.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<UserService> _logger;

        public UserService(IUserRepository userRepository, ILogger<UserService> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        public async Task<Entities.User?> AuthenticateAsync(string userName, string password)
        {
            try
            {
                return await _userRepository.AuthenticateAsync(userName, PasswordUtil.CreateHashMD5(password));
            }
            catch (Exception ex)
            {
                _logger.LogError($"[{nameof(UserService)} - {nameof(AuthenticateAsync)}] | {ex.Message}");
                return null;
            }
        }

        public async Task<Entities.User?> CreateAsync(Entities.User user)
        {
            try
            {
                return await _userRepository.CreateAsync(user);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[{nameof(UserService)} - {nameof(CreateAsync)}] | {ex.Message}");
                return null;
            }
        }

        public async Task<IEnumerable<Entities.User>?> GetAllAsync()
        {
            try
            {
                return await _userRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"[{nameof(UserService)} - {nameof(GetAllAsync)}] | {ex.Message}");
                return Enumerable.Empty<Entities.User>();
            }
        }

        public async Task<Entities.User?> GetAsync(Guid id)
        {
            try
            {
                return await _userRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[{nameof(UserService)} - {nameof(GetAsync)}] | {ex.Message}");
                return null;
            }
        }
    }
}
