using Dapper;
using Jcf.Control.Api.Applications.ClientApp.Entities;
using Jcf.Control.Api.Applications.ClientApp.Queries;
using Jcf.Control.Api.Applications.ClientApp.Repositories.IRepositories;
using Jcf.Control.Api.Core.Entities;
using Jcf.Control.Api.Data.Contexts;

namespace Jcf.Control.Api.Applications.ClientApp.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly AppDapperContext _appDapperContext;
        private readonly ILogger<ClientRepository> _logger;

        public ClientRepository(AppDbContext appDbContext, AppDapperContext appDapperContext, ILogger<ClientRepository> logger)
        {
            _appDbContext = appDbContext;
            _appDapperContext = appDapperContext;
            _logger = logger;
        }

        public async Task<Client?> CreateAsync(Client entity)
        {
            try
            {
                await _appDbContext.Clients.AddAsync(entity);
                await _appDbContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{nameof(ClientRepository)} | {nameof(CreateAsync)} | Error: {ex.Message}");
                return null;
            }
        }

        public bool Delete(Client entity)
        {
            try
            {
                entity.Delete();
                return Update(entity) is not null;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{nameof(ClientRepository)} | {nameof(Delete)} | Error: {ex.Message}");
                return false;
            }
        }

        public async Task<IEnumerable<Client>?> GetAllAsync()
        {
            try
            {
                var result = await _appDapperContext.Connection.QueryAsync<Client>(ClientQuery.GET_ALL, null, _appDapperContext.Transaction);
                return result ?? Enumerable.Empty<Client>();
            }
            catch (Exception ex)
            {
                _logger.LogError($"{nameof(ClientRepository)} | {nameof(GetAllAsync)} | Error: {ex.Message}");
                return Enumerable.Empty<Client>();
            }
        }

        public async Task<Client?> GetByIdAsync(Guid id)
        {
            try
            {
                var result = await _appDapperContext.Connection.QueryAsync<Client, Address, Client>(
                     ClientQuery.GET,
                     (client, address) =>
                     {
                         client.AddAddress(address);
                         return client;
                     },
                     new { Id = id },
                     _appDapperContext.Transaction,
                     splitOn: "Id" // Atenção: o splitOn define a partir de qual coluna é o segundo objeto (Address)
                );
                return result.FirstOrDefault();
            }
            catch (Exception ex)
            {
                _logger.LogError($"{nameof(ClientRepository)} | {nameof(GetByIdAsync)} | Error: {ex.Message}");
                return null;
            }
        }

        public async Task<IEnumerable<Client>?> GetByPageAsync(int page = 1, int pageSize = 10)
        {
            try
            {
                var result = await _appDapperContext.Connection.QueryAsync<Client>(ClientQuery.GET_ALL, null, _appDapperContext.Transaction);
                return result ?? Enumerable.Empty<Client>();
            }
            catch (Exception ex)
            {
                _logger.LogError($"{nameof(ClientRepository)} | {nameof(GetAllAsync)} | Error: {ex.Message}");
                return Enumerable.Empty<Client>();
            }
        }

        public Client? Update(Client entity)
        {
            try
            {
                _appDbContext.Clients.Update(entity);
                _appDbContext.SaveChanges();

                return entity;
            }
            catch (Exception ex)
            {
                _logger.LogError($"[{nameof(ClientRepository)} - {nameof(Update)}] | {ex.Message}");
                return null;
            }
        }
    }
}
