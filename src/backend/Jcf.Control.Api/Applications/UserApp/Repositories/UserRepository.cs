using Dapper;
using Jcf.Control.Api.Applications.AuthenticationApp.Services;
using Jcf.Control.Api.Applications.UserApp.Entities;
using Jcf.Control.Api.Applications.UserApp.Queries;
using Jcf.Control.Api.Applications.UserApp.Repositories.IRepositories;
using Jcf.Control.Api.Applications.UserApp.Services;
using Jcf.Control.Api.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Jcf.Control.Api.Applications.UserApp.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly AppDapperContext _appDapperContext;
        private readonly ILogger<UserRepository> _logger;

        public UserRepository(AppDbContext appDbContext, AppDapperContext appDapperContext, ILogger<UserRepository> logger)
        {
            _appDbContext = appDbContext;
            _appDapperContext = appDapperContext;
            _logger = logger;
        }

        public async Task<User?> AuthenticateAsync(string userName, string password)
        {
            try
            {
                return await _appDbContext.Users
                               .AsNoTracking()
                               .SingleOrDefaultAsync(_ => _.IsActive.Equals(true) && _.Login.Equals(userName) && _.Password.Equals(password));
            }
            catch (Exception ex)
            {
                _logger.LogError($"[{nameof(AuthService)} - {nameof(AuthenticateAsync)}] | {ex.Message}");
                return null;
            }
        }

        public async Task<User?> CreateAsync(User entity)
        {
            try
            {
                await _appDbContext.Users.AddAsync(entity);
                await _appDbContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{nameof(UserService)} | {nameof(CreateAsync)} | Error: {ex.Message}");
                return null;
            }
        }

        public bool Delete(User entity)
        {
            try
            {
                entity.Delete();
                return Update(entity) is not null;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{nameof(UserService)} | {nameof(Delete)} | Error: {ex.Message}");
                return false;
            }
        }

        public async Task<IEnumerable<User>?> GetAllAsync()
        {
            try
            {
                var result = await _appDapperContext.Connection.QueryAsync<User>(UserQuery.GET_ALL, null, _appDapperContext.Transaction);
                return result ?? Enumerable.Empty<User>();
            }
            catch (Exception ex)
            {
                _logger.LogError($"{nameof(UserService)} | {nameof(GetAllAsync)} | Error: {ex.Message}");
                return Enumerable.Empty<User>();
            }
        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            try
            {
                var result = await _appDapperContext.Connection.QueryFirstOrDefaultAsync<Entities.User>(
                   UserQuery.GET,
                   new { Id = id },
                   _appDapperContext.Transaction
               );
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{nameof(UserService)} | {nameof(GetByIdAsync)} | Error: {ex.Message}");
                return null;
            }
        }

        public User? Update(User entity)
        {
            try
            {
                _appDbContext.Users.Update(entity);
                _appDbContext.SaveChanges();

                return entity;
            }
            catch (Exception ex)
            {
                _logger.LogError($"[{nameof(UserRepository)} - {nameof(Update)}] | {ex.Message}");
                return null;
            }
        }
    }
}
