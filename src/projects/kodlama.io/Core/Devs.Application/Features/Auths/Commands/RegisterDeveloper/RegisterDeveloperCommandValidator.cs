using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.Auths.Commands.RegisterDeveloper
{
    public class RegisterDeveloperCommandValidator : AbstractValidator<RegisterDeveloperCommandRequest>
    {
        public RegisterDeveloperCommandValidator()
        {
            RuleFor(rd => rd.Email).EmailAddress().NotEmpty().NotNull();
            RuleFor(rd => rd.Password).NotEmpty().NotNull().MinimumLength(8);
        }
    }
}
