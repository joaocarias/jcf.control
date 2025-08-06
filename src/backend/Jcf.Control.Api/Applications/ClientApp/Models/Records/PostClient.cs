using Jcf.Control.Api.Core.Models.Records;

namespace Jcf.Control.Api.Applications.ClientApp.Models.Records
{
    public record PostClient
    (        
        string Name,
        string Email,
        string Phone,
        PostAddress Address
    );
}
