using Jcf.Control.Api.Applications.UserApp.Entities;
using Jcf.Control.Api.Applications.UserApp.Models.Records;
using Jcf.Control.Api.Core.Models;

namespace Jcf.Control.Api.Applications.UserApp.Services.IServices
{
    public interface IUserService
    {
        Task<User?> GetAsync(Guid id);
        Task<IEnumerable<User>?> GetAllAsync();
        Task<PageList<User>?> GetByPageAsync(int page = 1, int pageSize = 10);
        Task<User?> CreateAsync(User user);  
        User? Update(User user, PutUser putUser, Guid? userUpdateId);
        bool Delete(User user, Guid? userUpdateId);
    }
}
