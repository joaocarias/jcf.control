namespace Jcf.Control.Api.Core.Repositories.IRepositories
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<T?> GetByIdAsync(Guid id);
        Task<T?> CreateAsync(T entity);
        Task<IEnumerable<T>?> GetAllAsync();
        T? Update(T entity);
        bool Delete(T entity);
    }
}
