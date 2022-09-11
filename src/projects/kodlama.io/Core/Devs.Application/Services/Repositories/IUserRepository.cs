﻿using Core.Persistence.Repositories;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Services.Repositories
{
    public interface IUserRepository : IWriteRepository<User>, IReadRepository<User>
    {
        Task<IList<OperationClaim>> GetOperationClaimsAsync(int userId);
    }
}