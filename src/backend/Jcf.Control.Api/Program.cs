using Jcf.Control.Api.Applications.AuthenticationApp.Extensions;
using Jcf.Control.Api.Core.Extensions;

var builder = WebApplication.CreateBuilder(args);

Console.WriteLine(builder.Configuration.GetSection("EnvironmentName").Value);

// Add services to the container.
builder.Services.AddDatabaseConfiguration(builder.Configuration, builder.Environment);
builder.Services.AddAuthenticationConfiguration(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddCustomOpenApi();
builder.Services.AddCustomServices();
builder.Services.AddCorsConfiguration(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi("v1");

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "v1");
    });
}

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapOpenApi();

app.UseCors();

app.Run();
