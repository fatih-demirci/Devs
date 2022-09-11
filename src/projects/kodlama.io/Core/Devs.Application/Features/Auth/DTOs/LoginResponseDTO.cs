using Core.Security.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.Auth.DTOs
{
    public class LoginResponseDTO
    {
        public AccessToken AccessToken { get; set; }
    }
}
