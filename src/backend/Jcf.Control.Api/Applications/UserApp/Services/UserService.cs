﻿using Jcf.Control.Api.Applications.UserApp.Entities;
using Jcf.Control.Api.Applications.UserApp.Models.Records;
using Jcf.Control.Api.Applications.UserApp.Repositories.IRepositories;
using Jcf.Control.Api.Applications.UserApp.Services.IServices;
using Jcf.Control.Api.Core.Extensions;
using Jcf.Control.Api.Core.Uteis;

namespace Jcf.Control.Api.Applications.UserApp.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<UserService> _logger;

        public UserService(IUserRepository userRepository, ILogger<UserService> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        public async Task<Entities.User?> AuthenticateAsync(string userName, string password)
        {
            try
            {
                return await _userRepository.AuthenticateAsync(userName, PasswordUtil.CreateHashMD5(password));
            }
            catch (Exception ex)
            {
                _logger.LogError($"[{nameof(UserService)} - {nameof(AuthenticateAsync)}] | {ex.Message}");
                return null;
            }
        }

        public async Task<Entities.User?> CreateAsync(Entities.User user)
        {
            try
            {
                return await _userRepository.CreateAsync(user);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[{nameof(UserService)} - {nameof(CreateAsync)}] | {ex.Message}");
                return null;
            }
        }

        public bool Delete(User user, Guid? userUpdateId)
        {
            try
            {
                user.Delete(userUpdateId);
                user = _userRepository.Update(user);
                return user is not null && !user.IsActive; 
            }
            catch (Exception ex)
            {
                _logger.LogError($"[{nameof(UserService)} - {nameof(Delete)}] | {ex.Message}");
                return false;
            }
        }

        public async Task<IEnumerable<User>?> GetAllAsync()
        {
            try
            {
                return await _userRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"[{nameof(UserService)} - {nameof(GetAllAsync)}] | {ex.Message}");
                return Enumerable.Empty<User>();
            }
        }

        public async Task<User?> GetAsync(Guid id)
        {
            try
            {
                return await _userRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[{nameof(UserService)} - {nameof(GetAsync)}] | {ex.Message}");
                return null;
            }
        }

        public User? Update(User user, PutUser putUser, Guid? userUpdateId)
        {
            try
            {
                if(!user.Id.ValidadeIsEquals(putUser.Id))
                    return null;

                user.Edit(putUser.Name, putUser.Email, PasswordUtil.CreateHashMD5(putUser.Password), putUser.Login, userUpdateId);
                return _userRepository.Update(user);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[{nameof(UserService)} - {nameof(Update)}] | {ex.Message}");
                return null;
            }
        }
    }
}
