using Jcf.Control.Api.Applications.AuthenticationApp.Models.DTOs;
using Jcf.Control.Api.Applications.AuthenticationApp.Models.Responses;
using Jcf.Control.Api.Applications.AuthenticationApp.Services.IServices;
using Jcf.Control.Api.Core.Constants;
using Jcf.Control.Api.Core.Controllers;
using Jcf.Control.Api.Core.Models.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Jcf.Control.Api.Applications.AuthenticationApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : AppControllerBase
    {
        private readonly ILogger<AuthenticationController> _logger;
        private readonly IAuthService _authService;
        private readonly ITokenService _tokenService;

        public AuthenticationController(ILogger<AuthenticationController> logger, IAuthService authService, ITokenService tokenService)
        {
            _logger = logger;
            _authService = authService;
            _tokenService = tokenService;
        }

        [HttpPost("Login"), AllowAnonymous]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            var response = new ApiResponse();
            try
            {
                loginDTO.IsValidate();

                var user = await _authService.AuthenticateAsync(loginDTO.Email, loginDTO.Password);
                if (user == null)
                {
                    response.IsBadRequest(ApiResponseConstants.INVALID_LOGIN);
                    return BadRequest(response);
                }

                response.Result = new LoginResponse(true, user.ToDTO(), _tokenService.NewToken(user), ApiResponseConstants.SUCCESS);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[{nameof(AuthenticationController)} - {nameof(Login)}] | {ex.Message}");
                response.IsBadRequest(ex.Message);
                return BadRequest(response);
            }
        }
    }
}
