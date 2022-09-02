using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.ProgrammingLanguages.Commands.Create.CreateProgrammingLanguage
{
    public class CreateProgrammingLanguageCommandValidator : AbstractValidator<CreateProgrammingLanguageCommandRequest>
    {
        public CreateProgrammingLanguageCommandValidator()
        {
            RuleFor(pl => pl.Name).NotNull();
            RuleFor(pl => pl.Name).NotEmpty();
        }
    }
}
