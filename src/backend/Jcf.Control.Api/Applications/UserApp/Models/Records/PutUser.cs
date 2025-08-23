namespace Jcf.Control.Api.Applications.UserApp.Models.Records
{
    public record PutUser(
        Guid Id,
        string Name, 
        string Email, 
        string? Password, 
        string? Login
    );
}
