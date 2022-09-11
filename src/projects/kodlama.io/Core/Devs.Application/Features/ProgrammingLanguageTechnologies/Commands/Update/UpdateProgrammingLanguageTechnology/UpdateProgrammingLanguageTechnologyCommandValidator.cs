using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.ProgrammingLanguageTechnologies.Commands.Update.UpdateProgrammingLanguageTechnology
{
    public class UpdateProgrammingLanguageTechnologyCommandValidator : AbstractValidator<UpdateProgrammingLanguageTechnologyCommandRequest>
    {
        public UpdateProgrammingLanguageTechnologyCommandValidator()
        {
            RuleFor(uplt => uplt.Name).NotNull().NotEmpty();
        }
    }
}
