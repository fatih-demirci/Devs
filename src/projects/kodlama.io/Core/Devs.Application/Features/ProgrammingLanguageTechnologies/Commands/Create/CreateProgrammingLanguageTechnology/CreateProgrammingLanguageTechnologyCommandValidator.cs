using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.ProgrammingLanguageTechnologies.Commands.Create.CreateProgrammingLanguageTechnology
{
    public class CreateProgrammingLanguageTechnologyCommandValidator : AbstractValidator<CreateProgrammingLanguageTechnologyCommandRequest>
    {
        public CreateProgrammingLanguageTechnologyCommandValidator()
        {
            RuleFor(cplt => cplt.Name).NotNull().NotEmpty();
        }
    }
}
