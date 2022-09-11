using Devs.Application.Features.ProgrammingLanguageTechnologies.Commands.Create.CreateProgrammingLanguageTechnology;
using Devs.Application.Features.ProgrammingLanguageTechnologies.Commands.Delete.DeleteProgrammingLanguageTechnology;
using Devs.Application.Features.ProgrammingLanguageTechnologies.Commands.Update.UpdateProgrammingLanguageTechnology;
using Devs.Application.Features.ProgrammingLanguageTechnologies.DTOs;
using Devs.Application.Features.ProgrammingLanguageTechnologies.Models;
using Devs.Application.Features.ProgrammingLanguageTechnologies.Queries.GetListProgrammingLanguageTechnology;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Devs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammingLanguageTechnologiesController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] GetListProgrammingLanguageTechnologyQueryRequest getListProgrammingLanguageTechnologyQueryRequest)
        {
            ProgrammingLanguageTechnologyListModel programmingLanguageListModel = await Mediator.Send(getListProgrammingLanguageTechnologyQueryRequest);
            return Ok(programmingLanguageListModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProgrammingLanguageTechnologyCommandRequest getListProgrammingLanguageTechnologyCommandRequest)
        {
            CreatedProgrammingLanguageTechnologyDTO result = await Mediator.Send(getListProgrammingLanguageTechnologyCommandRequest);
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProgrammingLanguageTechnologyCommandRequest updateProgrammingLanguageTechnologyCommandRequest)
        {
            UpdatedProgrammingLanguageTechnologyDTO result = await Mediator.Send(updateProgrammingLanguageTechnologyCommandRequest);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] DeleteProgrammingLanguageTechnologyCommandRequest deleteProgrammingLanguageTechnologyCommandRequest)
        {
            DeleteProgrammingLanguageTechnologyCommandResponse result = await Mediator.Send(deleteProgrammingLanguageTechnologyCommandRequest);
            return Ok(result);
        }
    }
}
