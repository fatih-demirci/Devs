using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Devs.Application.Services.Repositories
{
    public interface IRefreshTokenRepository : IWriteRepository<RefreshToken>, IReadRepository<RefreshToken>
    {
    }
}
