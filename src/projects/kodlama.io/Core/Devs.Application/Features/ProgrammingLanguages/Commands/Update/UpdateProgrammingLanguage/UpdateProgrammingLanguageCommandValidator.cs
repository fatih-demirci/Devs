using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.ProgrammingLanguages.Commands.Update.UpdateProgrammingLanguage
{
    public class UpdateProgrammingLanguageCommandValidator : AbstractValidator<UpdateProgrammingLanguageCommandRequest>
    {
        public UpdateProgrammingLanguageCommandValidator()
        {
            RuleFor(upl => upl.Name).NotNull().NotEmpty();
        }
    }
}
