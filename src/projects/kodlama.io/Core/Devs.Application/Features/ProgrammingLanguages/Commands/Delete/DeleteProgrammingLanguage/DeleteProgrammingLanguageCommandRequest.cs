using Devs.Application.Features.ProgrammingLanguages.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.ProgrammingLanguages.Commands.Delete.DeleteProgrammingLanguage
{
    public class DeleteProgrammingLanguageCommandRequest : IRequest<DeleteProgrammingLanguageCommandResponse>
    {
        public int Id { get; set; }
    }
}
