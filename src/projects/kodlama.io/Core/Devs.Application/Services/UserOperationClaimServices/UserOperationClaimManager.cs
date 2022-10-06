using Core.Persistence.Paging;
using Core.Security.Entities;
using Devs.Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Services.UserOperationClaimServices
{
    public class UserOperationClaimManager : IUserOperationClaimService
    {
        IUserOperationClaimRepository _userOperationClaimRepository;

        public UserOperationClaimManager(IUserOperationClaimRepository userOperationClaimRepository)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
        }

        public async Task<IList<OperationClaim>> GetOperationClaimsByUserIdAsync(int userId)
        {
            IPaginate<UserOperationClaim> userOperationClaims =
            await _userOperationClaimRepository.GetListAsync(u => u.UserId == userId,
            include: u =>
            u.Include(u => u.OperationClaim));

            IList<OperationClaim> operationClaims =
                userOperationClaims.Items.Select(u => new OperationClaim
                {
                    Id = u.OperationClaim.Id,
                    Name = u.OperationClaim.Name,
                }).ToList();

            return operationClaims;
        }
    }
}
