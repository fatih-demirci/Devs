using Devs.Application.Features.ProgrammingLanguageTechnologies.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.ProgrammingLanguageTechnologies.Commands.Create.CreateProgrammingLanguageTechnology
{
    public class CreateProgrammingLanguageTechnologyCommandRequest : IRequest<CreatedProgrammingLanguageTechnologyDTO>
    {
        public string Name { get; set; }
        public int ProgrammingLanguageId { get; set; }
    }
}
