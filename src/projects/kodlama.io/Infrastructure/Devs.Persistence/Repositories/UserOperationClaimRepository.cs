using Core.Persistence.Repositories;
using Core.Security.Entities;
using Devs.Application.Services.Repositories;
using Devs.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Persistence.Repositories
{
    public class UserOperationClaimRepository : EfRepositoryBase<UserOperationClaim, DevsWriteContext, DevsReadContext>, IUserOperationClaimRepository
    {
        public UserOperationClaimRepository(DevsWriteContext devsWriteContext, DevsReadContext devsReadContext) : base(devsWriteContext, devsReadContext)
        {

        }
    }
}
