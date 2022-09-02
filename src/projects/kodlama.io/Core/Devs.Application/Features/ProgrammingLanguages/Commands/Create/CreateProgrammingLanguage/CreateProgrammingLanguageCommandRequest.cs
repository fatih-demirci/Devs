using Devs.Application.Features.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.ProgrammingLanguages.Commands.Create.CreateProgrammingLanguage
{
    public class CreateProgrammingLanguageCommandRequest : IRequest<CreatedProgrammingLanguageDTO>
    {
        public string Name { get; set; }
    }
}
