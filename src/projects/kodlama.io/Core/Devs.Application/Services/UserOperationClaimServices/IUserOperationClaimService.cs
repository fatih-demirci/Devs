using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Services.UserOperationClaimServices
{
    public interface IUserOperationClaimService
    {
        Task<IList<OperationClaim>> GetOperationClaimsByUserIdAsync(int userId);
    }
}
