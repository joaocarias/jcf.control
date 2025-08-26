using Jcf.Control.Api.Applications.UserApp.Entities;

namespace Jcf.Control.Api.Core.Repositories.IRepositories
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<T?> GetByIdAsync(Guid id);
        Task<T?> CreateAsync(T entity);
        Task<IEnumerable<T>?> GetAllAsync();
        Task<IEnumerable<T>?> GetByPageAsync(int page = 1, int pageSize = 10);
        T? Update(T entity);
        bool Delete(T entity);
    }
}
