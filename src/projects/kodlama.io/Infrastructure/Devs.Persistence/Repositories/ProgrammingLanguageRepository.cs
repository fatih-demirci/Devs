using Core.Persistence.Repositories;
using Devs.Application.Services.Repositories;
using Devs.Domain.Entities;
using Devs.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Persistence.Repositories
{
    public class ProgrammingLanguageRepository : EfRepositoryBase<ProgrammingLanguage, DevsWriteContext, DevsReadContext>, IProgrammingLanguageRepository
    {
        public ProgrammingLanguageRepository(DevsWriteContext devsWriteContexts, DevsReadContext devsReadContexts) : base(devsWriteContexts, devsReadContexts)
        {

        }
    }
}
