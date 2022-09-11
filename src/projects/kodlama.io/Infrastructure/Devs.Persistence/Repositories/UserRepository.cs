using Core.Persistence.Repositories;
using Core.Security.Entities;
using Devs.Application.Services.Repositories;
using Devs.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core.CustomTypeProviders;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Persistence.Repositories
{
    public class UserRepository : EfRepositoryBase<User, DevsWriteContext, DevsReadContext>, IUserRepository
    {
        public UserRepository(DevsWriteContext devsWriteContext, DevsReadContext devsReadContext) : base(devsWriteContext, devsReadContext)
        {

        }

        public async Task<IList<OperationClaim>> GetOperationClaimsAsync(int userId)
        {
            var result = from operationClaim in ReadContext.OperationClaims
                         join userOperationClaim in ReadContext.UserOperationClaims
                         on operationClaim.Id equals userOperationClaim.OperationClaimId
                         where userOperationClaim.UserId == userId
                         select new OperationClaim()
                         {
                             Id = operationClaim.Id,
                             Name = operationClaim.Name,
                         };
            return await result.ToListAsync();
        }
    }
}
