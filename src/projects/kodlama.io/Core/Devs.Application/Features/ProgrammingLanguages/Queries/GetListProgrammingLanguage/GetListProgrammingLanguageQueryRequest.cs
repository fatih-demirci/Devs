using Core.Application.Requests;
using Devs.Application.Features.ProgrammingLanguages.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.ProgrammingLanguages.Queries.GetListProgrammingLanguage
{
    public class GetListProgrammingLanguageQueryRequest : IRequest<ProgrammingLanguageListModel>
    {
        public PageRequest pageRequest { get; set; }
    }
}
