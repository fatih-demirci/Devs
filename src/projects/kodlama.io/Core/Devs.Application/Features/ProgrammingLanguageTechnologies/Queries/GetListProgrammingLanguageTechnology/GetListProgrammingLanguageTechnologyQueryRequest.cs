using Core.Application.Requests;
using Devs.Application.Features.ProgrammingLanguageTechnologies.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.ProgrammingLanguageTechnologies.Queries.GetListProgrammingLanguageTechnology
{
    public class GetListProgrammingLanguageTechnologyQueryRequest : IRequest<ProgrammingLanguageTechnologyListModel>
    {
        public PageRequest PageRequest { get; set; }
    }
}
