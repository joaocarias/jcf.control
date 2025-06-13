﻿using Jcf.Control.Api.Applications.UserApp.Entities;
using Jcf.Control.Api.Applications.UserApp.Models.Records;

namespace Jcf.Control.Api.Applications.UserApp.Services.IServices
{
    public interface IUserService
    {
        Task<User?> GetAsync(Guid id);
        Task<IEnumerable<User>?> GetAllAsync();
        Task<User?> CreateAsync(User user);  
        User? Update(User user, PutUser putUser, Guid? userUpdateId);
        bool Delete(User user, Guid? userUpdateId);
    }
}
