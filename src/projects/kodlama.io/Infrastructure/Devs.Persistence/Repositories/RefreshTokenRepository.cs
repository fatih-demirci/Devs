using Core.Persistence.Repositories;
using Core.Security.Entities;
using Devs.Application.Services.Repositories;
using Devs.Persistence.Contexts;

namespace Devs.Persistence.Repositories
{
    public class RefreshTokenRepository : EfRepositoryBase<RefreshToken, DevsWriteContext, DevsReadContext>, IRefreshTokenRepository
    {
        public RefreshTokenRepository(DevsWriteContext devsWriteContext, DevsReadContext devsReadContext) : base(devsWriteContext, devsReadContext)
        {

        }
    }
}
