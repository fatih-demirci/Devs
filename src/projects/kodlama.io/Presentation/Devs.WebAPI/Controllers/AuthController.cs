using Core.Security.Entities;
using Core.Security.Enums;
using Core.Security.Hashing;
using Core.Security.JWT;
using Devs.Application.Features.Auth.Commands.RegisterDeveloper;
using Devs.Application.Features.Auth.DTOs;
using Devs.Application.Features.Auth.Queries.Login;
using Devs.Application.Services.Repositories;
using Devs.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Devs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        IDeveloperRepository _developerRepository;
        ITokenHelper _tokenHelper;
        IUserOperationClaimRepository _userOperationClaimRepository;
        IUserRepository _userRepository;

        public AuthController(IDeveloperRepository developerRepository, ITokenHelper tokenHelper, IUserOperationClaimRepository userOperationClaimRepository, IUserRepository userRepository = null)
        {
            _developerRepository = developerRepository;
            _tokenHelper = tokenHelper;
            _userOperationClaimRepository = userOperationClaimRepository;
            _userRepository = userRepository;
        }

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
