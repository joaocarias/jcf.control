using Jcf.Control.Api.Applications.UserApp.Entities;

namespace Jcf.Control.Api.Applications.UserApp.Services.IServices
{
    public interface IUserService
    {
        Task<User?> GetAsync(Guid id);
        Task<IEnumerable<User>?> GetAllAsync();
        Task<User?> CreateAsync(User user);        
    }
}
