using Devs.Application.Services.AuthServices;
using Core.Security.Entities;
using Core.Security.Enums;
using Core.Security.Hashing;
using Core.Security.JWT;
using Devs.Application.Features.Auths.DTOs;
using Devs.Application.Features.Auths.Rules;
using Devs.Application.Services.Repositories;
using Devs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Devs.Application.Features.Auths.Commands.RegisterDeveloper
{
    public class RegisterDeveloperCommandHandler : IRequestHandler<RegisterDeveloperCommandRequest, LoginResponseDTO>
    {
        private readonly IDeveloperRepository _developerRepository;
        private readonly AuthBusinessRules _authBusinessRules;
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly IAuthService _authService;

        public RegisterDeveloperCommandHandler
            (
            IDeveloperRepository developerRepository,
            AuthBusinessRules authBusinessRules,
            IUserOperationClaimRepository userOperationClaimRepository,
            IAuthService authService
            )
        {
            _developerRepository = developerRepository;
            _authBusinessRules = authBusinessRules;
            _userOperationClaimRepository = userOperationClaimRepository;
            _authService = authService;
        }

        public async Task<LoginResponseDTO> Handle(RegisterDeveloperCommandRequest request, CancellationToken cancellationToken)
        {
            await _authBusinessRules.EmailAddressCanNotBeDuplicated(request.Email);

            HashingHelper.CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
            Developer developer = new(request.FirstName, request.LastName)
            {
                Email = request.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                FirstName = request.FirstName,
                LastName = request.LastName,
                AuthenticatorType = AuthenticatorType.None,
                GithubURL = request.GithubURL,
                Status = true,
            };
            using TransactionScope transactionScope = new(TransactionScopeAsyncFlowOption.Enabled);
            try
            {
                await _developerRepository.AddAsync(developer);
                await _userOperationClaimRepository.AddAsync(new UserOperationClaim(0, developer.Id, 2));

                AccessToken createdAccessToken = await _authService.CreateAccessToken(developer);
                RefreshToken createdRefreshToken = await _authService.CreateRefreshToken(developer, request.IpAddress);
                RefreshToken addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken);
                LoginResponseDTO loginResponseDTO = new() { AccessToken = createdAccessToken, RefreshToken = createdRefreshToken };
                transactionScope.Complete();
                return loginResponseDTO;
            }
            catch (Exception)
            {
                transactionScope.Dispose();
                throw;
            }
        }

    }
}
