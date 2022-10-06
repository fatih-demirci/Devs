using Core.Security.Entities;
using Core.Security.JWT;
using Devs.Application.Services.Repositories;
using Devs.Application.Services.UserOperationClaimServices;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Devs.Application.Services.AuthServices
{
    public class AuthManager : IAuthService
    {
        private readonly ITokenHelper _tokenHelper;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly IUserOperationClaimService _userOperationClaimService;

        public AuthManager(IUserOperationClaimRepository userOperationClaimRepository,
            ITokenHelper tokenHelper,
            IRefreshTokenRepository refreshTokenRepository
,
            IUserOperationClaimService userOperationClaimService)
        {
            _tokenHelper = tokenHelper;
            _refreshTokenRepository = refreshTokenRepository;
            _userOperationClaimService = userOperationClaimService;
        }

        public async Task<RefreshToken> AddRefreshToken(RefreshToken refreshToken)
        {
            RefreshToken addedRefreshToken = await _refreshTokenRepository.AddAsync(refreshToken);
            refreshToken.User = null;
            return addedRefreshToken;
        }

        public async Task<AccessToken> CreateAccessToken(User user)
        {
            IList<OperationClaim> operationClaims = await _userOperationClaimService.GetOperationClaimsByUserIdAsync(user.Id);
            AccessToken accessToken = _tokenHelper.CreateToken(user, operationClaims);
            return accessToken;
        }

        public Task<RefreshToken> CreateRefreshToken(User user, string ipAddress)
        {
            RefreshToken refreshToken = _tokenHelper.CreateRefreshToken(user, ipAddress);
            return Task.FromResult(refreshToken);
        }
    }
}
