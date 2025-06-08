using Jcf.Control.Api.Applications.UserApp.Entities;
using Jcf.Control.Api.Core.Repositories.IRepositories;

namespace Jcf.Control.Api.Applications.UserApp.Repositories.IRepositories
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<User?> AuthenticateAsync(string userName, string password);
    }
}
