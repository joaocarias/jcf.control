using Jcf.Control.Api.Applications.UserApp.Entities;
using Jcf.Control.Api.Applications.UserApp.Models.Records;
using Jcf.Control.Api.Applications.UserApp.Services.IServices;
using Jcf.Control.Api.Core.Constants;
using Jcf.Control.Api.Core.Controllers;
using Jcf.Control.Api.Core.Models.Responses;
using Jcf.Control.Api.Core.Uteis;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Jcf.Control.Api.Applications.UserApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : AppControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        /// <summary>
        /// Retorna um específico registro.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var response = new ApiResponse();
            try
            {
                var user = await _userService.GetAsync(id);
                if (user is null)
                {
                    response.IsNotFound();
                    return NotFound(response);
                }

                response.IsOk(user.ToDTO());
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[{nameof(UserController)} - {nameof(Get)}] | {ex.Message}");
                response.IsBadRequest(ex.Message);
                return BadRequest(response);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get(int page = 1, int pageSize = 10)
        {
            var response = new ApiResponse();
            try
            {
                var users = await _userService.GetByPageAsync(page, pageSize);
                if (users is null)
                {
                    response.IsNotFound();
                    return NotFound(response);
                }

                response.IsOk(users.Select(x => x.ToDTO()));
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[{nameof(UserController)} - {nameof(Get)}] | {ex.Message}");
                response.IsBadRequest(ex.Message);
                return BadRequest(response);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int page = 1, int pageSize = 10)
        {
            var response = new ApiResponse();
            try
            {
                var users = await _userService.GetAllAsync();
                if (users is null)
                {
                    response.IsNotFound();
                    return NotFound(response);
                }

                response.IsOk(users.Select(x => x.ToDTO()));
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[{nameof(UserController)} - {nameof(Get)}] | {ex.Message}");
                response.IsBadRequest(ex.Message);
                return BadRequest(response);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostUser newUser)
        {
            var response = new ApiResponse();
            try
            {
                var user = await _userService.CreateAsync(new User(newUser.Name, newUser.Email, string.IsNullOrEmpty(newUser.Password) ? PasswordUtil.CreateHashMD5(PasswordUtil.PasswordDefault) : PasswordUtil.CreateHashMD5(newUser.Password), string.IsNullOrEmpty(newUser.Login) ? newUser.Email : newUser.Login, RolesConstants.BASIC, GetUserIdFromToken()));
                if (user is null)
                {
                    response.IsBadRequest(ApiResponseConstants.NOT_CREATE);
                    return BadRequest(response);
                }

                return CreatedAtAction(nameof(Get), new { id = user.Id }, new LoginResponseDTO() { Result = user.ToDTO(), Token = string.Empty });

            }
            catch (Exception ex)
            {
                _logger.LogError($"[{nameof(UserController)} - {nameof(Get)}] | {ex.Message}");
                response.IsBadRequest(ex.Message);
                return BadRequest(response);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([Required] Guid id, [FromBody] PutUser editUser)
        {
            var response = new ApiResponse();
            try
            {
                if(id != editUser.Id)
                {
                    response.IsBadRequest(ApiResponseConstants.UPDATE_IDS_DISTINCTS);
                    return BadRequest(response);
                }

                var user = await _userService.GetAsync(id);
                if (user is null)
                {
                    response.IsBadRequest(ApiResponseConstants.NOT_FOUND);
                    return BadRequest(response);
                }

                user = _userService.Update(user, editUser, GetUserIdFromToken());
                return CreatedAtAction(nameof(Get), new { id = user?.Id }, new LoginResponseDTO() { Result = user?.ToDTO(), Token = string.Empty });

            }
            catch (Exception ex)
            {
                _logger.LogError($"[{nameof(UserController)} - {nameof(Get)}] | {ex.Message}");
                response.IsBadRequest(ex.Message);
                return BadRequest(response);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([Required] Guid id)
        {
            var response = new ApiResponse();
            try
            {
                var user = await _userService.GetAsync(id);
                if (user is null)
                {
                    response.IsBadRequest(ApiResponseConstants.NOT_FOUND);
                    return BadRequest(response);
                }

                var _hasDelete = _userService.Delete(user, GetUserIdFromToken());
                if( !_hasDelete)
                {
                    response.IsBadRequest(ApiResponseConstants.ERROR_DELETE);
                    return BadRequest(response);
                }

                response.IsOk(null);
                return Ok(response); 

            }
            catch (Exception ex)
            {
                _logger.LogError($"[{nameof(UserController)} - {nameof(Get)}] | {ex.Message}");
                response.IsBadRequest(ex.Message);
                return BadRequest(response);
            }
        }
    }
}
