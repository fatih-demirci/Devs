using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.ProgrammingLanguageTechnologies.DTOs
{
    public class UpdatedProgrammingLanguageTechnologyDTO
    {
        public int Id { get; set; }
        public int ProgrammingLanguageId { get; set; }
        public string ProgrammingLanguageName { get; set; }
        public string ProgrammingLanguageTechnologyName { get; set; }
    }
}
