using Devs.Application.Features.ProgrammingLanguageTechnologies.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.ProgrammingLanguageTechnologies.Commands.Update.UpdateProgrammingLanguageTechnology
{
    public class UpdateProgrammingLanguageTechnologyCommandRequest : IRequest<UpdatedProgrammingLanguageTechnologyDTO>
    {
        public int Id { get; set; }
        public int ProgrammingLanguageId { get; set; }
        public string Name { get; set; }
    }
}
