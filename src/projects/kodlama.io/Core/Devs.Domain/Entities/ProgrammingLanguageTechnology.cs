using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Domain.Entities
{
    public class ProgrammingLanguageTechnology : Entity
    {
        public string Name { get; set; }
        public int ProgrammingLanguageId { get; set; }
        public ProgrammingLanguage? ProgrammingLanguage { get; set; }

        public ProgrammingLanguageTechnology()
        {

        }

        public ProgrammingLanguageTechnology(int id, int programmingLanguageId, string name)
        {
            Id = id;
            ProgrammingLanguageId = programmingLanguageId;
            Name = name;
        }
    }
}
