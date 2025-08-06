using Jcf.Control.Api.Applications.ClientApp.Entities;
using Jcf.Control.Api.Applications.ClientApp.Models.Records;
using Jcf.Control.Api.Applications.ClientApp.Repositories.IRepositories;
using Jcf.Control.Api.Applications.ClientApp.Services.IServices;
using Jcf.Control.Api.Applications.UserApp.Entities;
using Jcf.Control.Api.Applications.UserApp.Models.Records;
using Jcf.Control.Api.Applications.UserApp.Services;
using Jcf.Control.Api.Core.Extensions;
using Jcf.Control.Api.Core.Uteis;

namespace Jcf.Control.Api.Applications.ClientApp.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly ILogger<ClientService> _logger;

        public ClientService(IClientRepository clientRepository, ILogger<ClientService> logger)
        {
            _clientRepository = clientRepository;
            _logger = logger;
        }

        public async Task<Client?> CreateAsync(Client entity)
        {
            try
            {
                return await _clientRepository.CreateAsync(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[{nameof(ClientService)} - {nameof(CreateAsync)}] | {ex.Message}");
                return null;
            }
        }

        public bool Delete(Client entity, Guid? userUpdateId)
        {
            try
            {
                entity.Delete(userUpdateId);
                entity = _clientRepository.Update(entity);
                return entity is not null && !entity.IsActive;
            }
            catch (Exception ex)
            {
                _logger.LogError($"[{nameof(ClientService)} - {nameof(Delete)}] | {ex.Message}");
                return false;
            }
        }

        public async Task<IEnumerable<Client>?> GetAllAsync()
        {
            try
            {
                return await _clientRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"[{nameof(ClientService)} - {nameof(GetAllAsync)}] | {ex.Message}");
                return Enumerable.Empty<Client>();
            }
        }

        public async Task<Client?> GetAsync(Guid id)
        {
            try
            {
                return await _clientRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[{nameof(ClientService)} - {nameof(GetAsync)}] | {ex.Message}");
                return null;
            }
        }

        public Client? Update(Client entity, PutClient putEntity, Guid? userUpdateId)
        {
            try
            {
                if (!entity.Id.ValidadeIsEquals(putEntity.Id))
                    return null;

                entity.Edit(putEntity.Name, putEntity.Email, putEntity.Phone, userUpdateId);
                return _clientRepository.Update(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[{nameof(UserService)} - {nameof(Update)}] | {ex.Message}");
                return null;
            }
        }
    }
}
