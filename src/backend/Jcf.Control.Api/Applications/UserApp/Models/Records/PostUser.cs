namespace Jcf.Control.Api.Applications.UserApp.Models.Records
{
    public record PostUser(
        string Name,
        string Email,
        string? Password,
        string? Login
    );
}
