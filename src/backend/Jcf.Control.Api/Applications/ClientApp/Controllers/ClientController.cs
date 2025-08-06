using Jcf.Control.Api.Applications.ClientApp.Entities;
using Jcf.Control.Api.Applications.ClientApp.Models.Records;
using Jcf.Control.Api.Applications.ClientApp.Services.IServices;
using Jcf.Control.Api.Core.Constants;
using Jcf.Control.Api.Core.Controllers;
using Jcf.Control.Api.Core.Entities;
using Jcf.Control.Api.Core.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace Jcf.Control.Api.Applications.ClientApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : AppControllerBase
    {
        private readonly ILogger<ClientController> _logger;
        private readonly IClientService _clientService;

        public ClientController(ILogger<ClientController> logger, IClientService clientService)
        {
            _logger = logger;
            _clientService = clientService;
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
                var myObj = await _clientService.GetAsync(id);
                if (myObj is null)
                {
                    response.IsNotFound();
                    return NotFound(response);
                }

                response.IsOk(myObj.ToDTO());
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[{nameof(ClientController)} - {nameof(Get)}] | {ex.Message}", ex);
                response.IsBadRequest(ex.Message);
                return BadRequest(response);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = new ApiResponse();
            try
            {
                var users = await _clientService.GetAllAsync();
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
                _logger.LogError($"[{nameof(ClientController)} - {nameof(Get)}] | {ex.Message}", ex);
                response.IsBadRequest(ex.Message);
                return BadRequest(response);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostClient newObj)
        {
            var response = new ApiResponse();
            try
            {
                var userCreateId = GetUserIdFromToken();
                var obj = await _clientService.CreateAsync(new Client(newObj.Name, newObj.Email, newObj.Phone, new Address(newObj.Address.Place, newObj.Address.Number, newObj.Address.Neighborhood, newObj.Address.Complement, newObj.Address.ZipCode, newObj.Address.City, newObj.Address.State, userCreateId), userCreateId));
                if (obj is null)
                {
                    response.IsBadRequest(ApiResponseConstants.NOT_CREATE);
                    return BadRequest(response);
                }

                return CreatedAtAction(nameof(Get), new { id = obj.Id }, new ApiResponse { Result = obj.ToDTO(), StatusCode = HttpStatusCode.Created});
            }
            catch (Exception ex)
            {
                _logger.LogError($"[{nameof(ClientController)} - {nameof(Get)}] | {ex.Message}", ex);
                response.IsBadRequest(ex.Message);
                return BadRequest(response);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([Required] Guid id, [FromBody] PutClient editObj)
        {
            var response = new ApiResponse();
            try
            {
                if (id != editObj.Id)
                {
                    response.IsBadRequest(ApiResponseConstants.UPDATE_IDS_DISTINCTS);
                    return BadRequest(response);
                }

                var obj = await _clientService.GetAsync(id);
                if (obj is null)
                {
                    response.IsBadRequest(ApiResponseConstants.NOT_FOUND);
                    return BadRequest(response);
                }

                obj = _clientService.Update(obj, editObj, GetUserIdFromToken());
                return CreatedAtAction(nameof(Get), new { id = obj?.Id }, new ApiResponse { Result = obj?.ToDTO() });
            }
            catch (Exception ex)
            {
                _logger.LogError($"[{nameof(ClientController)} - {nameof(Get)}] | {ex.Message}");
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
                var user = await _clientService.GetAsync(id);
                if (user is null)
                {
                    response.IsBadRequest(ApiResponseConstants.NOT_FOUND);
                    return BadRequest(response);
                }

                var _hasDelete = _clientService.Delete(user, GetUserIdFromToken());
                if (!_hasDelete)
                {
                    response.IsBadRequest(ApiResponseConstants.ERROR_DELETE);
                    return BadRequest(response);
                }

                response.IsOk(null);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[{nameof(ClientController)} - {nameof(Get)}] | {ex.Message}");
                response.IsBadRequest(ex.Message);
                return BadRequest(response);
            }
        }
    }
}
