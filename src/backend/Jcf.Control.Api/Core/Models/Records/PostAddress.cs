namespace Jcf.Control.Api.Core.Models.Records
{
    public record PostAddress
    (
        string? Place,
        string? Number,
        string? Neighborhood,
        string? Complement,
        string? ZipCode,
        string? City,
        string? State
    );
}
