using Jcf.Control.Api.Core.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Jcf.Control.Api.Core.Controllers
{
    [Authorize]
    public class AppControllerBase : ControllerBase
    {
        protected Guid? GetUserIdFromToken()
        {
            try
            {
                var userId = (HttpContext.User.Identity as ClaimsIdentity)?.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypeConstants.USER_ID));
                if (userId is null || !Guid.TryParse(userId.Value, out var id))
                    return null;
                return id;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{nameof(AppControllerBase)} | {nameof(GetUserIdFromToken)}: " + ex.ToString());
            }

            return null;
        }
    }
}
