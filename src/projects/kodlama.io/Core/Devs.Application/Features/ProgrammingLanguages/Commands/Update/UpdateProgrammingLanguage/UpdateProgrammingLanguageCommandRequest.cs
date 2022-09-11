using Devs.Application.Features.ProgrammingLanguages.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.ProgrammingLanguages.Commands.Update.UpdateProgrammingLanguage
{
    public class UpdateProgrammingLanguageCommandRequest : IRequest<UpdatedProgrammingLanguageDTO>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
