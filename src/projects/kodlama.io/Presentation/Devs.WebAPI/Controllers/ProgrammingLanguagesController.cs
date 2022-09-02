using Devs.Application.Features.DTOs;
using Devs.Application.Features.Models;
using Devs.Application.Features.ProgrammingLanguages.Commands.Create.CreateProgrammingLanguage;
using Devs.Application.Features.ProgrammingLanguages.Commands.Delete.DeleteProgrammingLanguage;
using Devs.Application.Features.ProgrammingLanguages.Commands.Update.UpdateProgrammingLanguage;
using Devs.Application.Features.ProgrammingLanguages.Queries.GetByIdProgrammingLanguage;
using Devs.Application.Features.ProgrammingLanguages.Queries.GetListProgrammingLanguage;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Devs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammingLanguagesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add(CreateProgrammingLanguageCommandRequest createProgrammingLanguageRequest)
        {
            CreatedProgrammingLanguageDTO result = await Mediator.Send(createProgrammingLanguageRequest);
            return Created("", result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Add([FromRoute] GetByIdProgrammingLanguageQueryRequest getByIdProgrammingLanguageRequest)
        {
            ProgrammingLanguageGetByIdDTO result = await Mediator.Send(getByIdProgrammingLanguageRequest);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] GetListProgrammingLanguageQueryRequest getListProgrammingLanguageRequest)
        {
            ProgrammingLanguageListModel result = await Mediator.Send(getListProgrammingLanguageRequest);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateProgrammingLanguageCommandRequest updateProgrammingLanguageCommandRequest)
        {
            UpdatedProgrammingLanguageDTO result = await Mediator.Send(updateProgrammingLanguageCommandRequest);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] DeleteProgrammingLanguageCommandRequest deleteProgrammingLanguageCommandRequest)
        {
            DeleteProgrammingLanguageCommandResponse result = await Mediator.Send(deleteProgrammingLanguageCommandRequest);
            return Ok(result);
        }
    }
}
