using Jcf.Control.Api.Applications.ClientApp.Entities;
using Jcf.Control.Api.Applications.ClientApp.Models.Records;

namespace Jcf.Control.Api.Applications.ClientApp.Services.IServices
{
    public interface IClientService
    {
        Task<Client?> GetAsync(Guid id);
        Task<IEnumerable<Client>?> GetAllAsync();
        Task<Client?> CreateAsync(Client entity);
        Client? Update(Client entity, PutClient putEntity, Guid? userUpdateId);
        bool Delete(Client entity, Guid? userUpdateId);
    }
}
