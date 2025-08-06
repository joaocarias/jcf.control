using Jcf.Control.Api.Core.Entities;

namespace Jcf.Control.Api.Applications.ClientApp.Models.Records
{
    public record PutClient
    (
        Guid Id,
        string Name,
        string Email,
        string Phone
       // Address Address
    );
}
