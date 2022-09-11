using Devs.Application.Features.Auth.Commands.RegisterDeveloper;
using Devs.Application.Features.Auth.DTOs;
using Devs.Application.Features.Auth.Queries.Login;
using Microsoft.AspNetCore.Mvc;

namespace Devs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> RegisterDeveloper([FromBody] RegisterDeveloperCommandRequest registerDeveloperCommandRequest)
        {
            LoginResponseDTO result = await Mediator.Send(registerDeveloperCommandRequest);
            return Created("", result);
        }

        [HttpGet]
        public async Task<IActionResult> Login([FromQuery] LoginQueryRequest loginQueryRequest)
        {
            LoginResponseDTO result = await Mediator.Send(loginQueryRequest);
            return Ok(result);
        }
    }
}
