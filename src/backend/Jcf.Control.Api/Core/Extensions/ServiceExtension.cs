﻿using Jcf.Control.Api.Applications.AuthenticationApp.Services;
using Jcf.Control.Api.Applications.AuthenticationApp.Services.IServices;
using Jcf.Control.Api.Applications.UserApp.Repositories;
using Jcf.Control.Api.Applications.UserApp.Repositories.IRepositories;
using Jcf.Control.Api.Applications.UserApp.Services;
using Jcf.Control.Api.Applications.UserApp.Services.IServices;

namespace Jcf.Control.Api.Core.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
