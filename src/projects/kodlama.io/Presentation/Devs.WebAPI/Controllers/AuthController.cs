using Devs.Application.Features.Auths.Commands.RegisterDeveloper;
using Devs.Application.Features.Auths.DTOs;
using Devs.Application.Features.Auths.Queries.Login;
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
            registerDeveloperCommandRequest.IpAddress = GetIpAddress();
            LoginResponseDTO result = await Mediator.Send(registerDeveloperCommandRequest);
            SetRefreshTokenToCookie(result.RefreshToken);
            return Created("", result);
        }

        [HttpGet]
        public async Task<IActionResult> Login([FromQuery] LoginQueryRequest loginQueryRequest)
        {
            loginQueryRequest.IpAddress = GetIpAddress();
            LoginResponseDTO result = await Mediator.Send(loginQueryRequest);
            SetRefreshTokenToCookie(result.RefreshToken);
            return Ok(result);
        }
    }
}
