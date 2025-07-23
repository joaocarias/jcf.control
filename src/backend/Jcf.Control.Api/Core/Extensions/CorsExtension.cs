namespace Jcf.Control.Api.Core.Extensions
{
    public static class CorsExtension
    {
        public static IServiceCollection AddCorsConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var corsSettings = configuration.GetSection("CorsSettings");
            var allowedOrigins = corsSettings.GetSection("AllowedOrigins").Get<string[]>() ?? Array.Empty<string>();
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                {
                    builder.WithOrigins(allowedOrigins)
                           .AllowAnyMethod()
                           .AllowAnyHeader()
                           .AllowCredentials(); // se usar autenticação por cookies;
                });
            });
            return services;
        }
    }
}
