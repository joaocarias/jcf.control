using Jcf.Control.Api.Core.Models.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Jcf.Control.Api.Core.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(Roles = "ADMIN")]
    public class AppConfigController : AppControllerBase
    {
        private readonly ILogger<AppConfigController> _logger;

        public AppConfigController(ILogger<AppConfigController> logger)
        {
            _logger = logger;
        }

        [HttpGet("GetRoles")]
        public IActionResult GetRoles()
        {
            var response = new ApiResponse();
            try
            {
                var roles = new List<string> { "ADMIN", "BASIC" };
                response.IsOk(roles);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[{nameof(AppConfigController)} - {nameof(GetRoles)}] | {ex.Message}", ex);
                response.IsBadRequest(ex.Message);
                return BadRequest(response);
            }
        }
    }
}
