using Core.Persistence.Paging;
using Devs.Application.Features.ProgrammingLanguages.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.ProgrammingLanguages.Models
{
    public class ProgrammingLanguageListModel : BasePageableModel
    {
        public IList<ProgrammingLanguageListDTO> Items { get; set; }
    }
}
