using Dapper;
using Jcf.Control.Api.Applications.AuthenticationApp.Services;
using Jcf.Control.Api.Applications.UserApp.Entities;
using Jcf.Control.Api.Applications.UserApp.Queries;
using Jcf.Control.Api.Applications.UserApp.Repositories.IRepositories;
using Jcf.Control.Api.Core.Models;
using Jcf.Control.Api.Core.Uteis;
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
                _logger.LogError($"{nameof(UserRepository)} | {nameof(CreateAsync)} | Error: {ex.Message}");
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
                _logger.LogError($"{nameof(UserRepository)} | {nameof(Delete)} | Error: {ex.Message}");
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
                _logger.LogError($"{nameof(UserRepository)} | {nameof(GetAllAsync)} | Error: {ex.Message}");
                return Enumerable.Empty<User>();
            }
        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            try
            {
                var result = await _appDapperContext.Connection.QueryFirstOrDefaultAsync<User>(
                   UserQuery.GET,
                   new { Id = id },
                   _appDapperContext.Transaction
               );
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{nameof(UserRepository)} | {nameof(GetByIdAsync)} | Error: {ex.Message}");
                return null;
            }
        }

        public async Task<PageList<User>?> GetByPageAsync(int page = 1, int pageSize = 10)
        {
            try
            {
                var (Offset, PageSize) = PaginationUtil.GetPagination(page, pageSize);
                var query = $" {UserQuery.GET_PAGINATE} \n {UserQuery.GET_COUNT} ";


                using var multi = await _appDapperContext.Connection.QueryMultipleAsync(
                            query,
                            new { Offset, PageSize = pageSize },
                            _appDapperContext.Transaction
                        );

                var list = await multi.ReadAsync<User>();
                var count = await multi.ReadFirstAsync<int>();

                return new PageList<User>(list, page, pageSize, count);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{nameof(UserRepository)} | {nameof(GetByPageAsync)} | Error: {ex.Message}");
                return new PageList<User>(new List<User>(), 0, 0, 0));
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
