using Core.Persistence.Paging;
using Devs.Application.Features.ProgrammingLanguageTechnologies.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.ProgrammingLanguageTechnologies.Models
{
    public class ProgrammingLanguageTechnologyListModel : BasePageableModel
    {
        public IList<ProgrammingLanguageTechnologyListDTO> Items { get; set; }
    }
}
