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
    public class ProgrammingLanguageTechnologyRepository : EfRepositoryBase<ProgrammingLanguageTechnology, DevsWriteContext, DevsReadContext>, IProgrammingLanguageTechnologyRepository
    {
        public ProgrammingLanguageTechnologyRepository(DevsWriteContext devsWriteContext, DevsReadContext devsReadContext) : base(devsWriteContext, devsReadContext)
        {

        }
    }
}
