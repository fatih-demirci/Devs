using Core.Security.DTOs;
using Devs.Application.Features.Auths.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.Auths.Commands.RegisterDeveloper
{
    public class RegisterDeveloperCommandRequest : UserForRegisterDTOBase, IRequest<LoginResponseDTO>
    {
        public string GithubURL { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IpAddress { get; set; }
    }
}
