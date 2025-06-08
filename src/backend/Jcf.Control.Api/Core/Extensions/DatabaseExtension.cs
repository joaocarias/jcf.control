using Jcf.Control.Api.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Jcf.Control.Api.Core.Extensions
{
    public static class DatabaseExtension
    {
        public static IServiceCollection AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
        {
            var consoleLogger = LoggerFactory.Create(builder => builder.AddConsole());

            services.AddDbContext<AppDbContext>(options =>
            {                     
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
                options.EnableSensitiveDataLogging();

                if (environment.IsDevelopment())
                {
                    options.UseLoggerFactory(consoleLogger).EnableDetailedErrors();                   
                    options.ConfigureWarnings(warnings => warnings.Log(RelationalEventId.PendingModelChangesWarning));
                }
            });

            services.AddScoped<AppDapperContext>();

            return services;
        }
    }
}
