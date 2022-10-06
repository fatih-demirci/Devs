using Core.Security.DTOs;
using Devs.Application.Features.Auths.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.Auths.Queries.Login
{
    public class LoginQueryRequest : UserForLoginDTO, IRequest<LoginResponseDTO>
    {
    }
}
