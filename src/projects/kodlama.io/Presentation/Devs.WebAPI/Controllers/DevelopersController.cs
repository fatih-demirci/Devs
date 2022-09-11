using Devs.Application.Features.Developers.Commands.Update.UpdateDeveloper;
using Devs.Application.Features.Developers.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Devs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevelopersController : BaseController
    {
        [HttpPut]
        public async Task<IActionResult> Update(UpdateDeveloperCommandRequest updateDeveloperCommandRequest)
        {
            UpdatedDeveloperDTO result = await Mediator.Send(updateDeveloperCommandRequest);
            return Ok(result);
        }
    }
}
