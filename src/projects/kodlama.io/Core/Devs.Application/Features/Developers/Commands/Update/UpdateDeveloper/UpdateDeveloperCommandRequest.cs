using Devs.Application.Features.Developers.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.Developers.Commands.Update.UpdateDeveloper
{
    public class UpdateDeveloperCommandRequest : IRequest<UpdatedDeveloperDTO>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string GithubURL { get; set; }
    }
}
