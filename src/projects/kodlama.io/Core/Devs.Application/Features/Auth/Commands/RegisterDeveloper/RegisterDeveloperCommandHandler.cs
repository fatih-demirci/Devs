using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Core.Security.Enums;
using Core.Security.Hashing;
using Core.Security.JWT;
using Devs.Application.Features.Auth.DTOs;
using Devs.Application.Features.Auth.Rules;
using Devs.Application.Services.Repositories;
using Devs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Devs.Application.Features.Auth.Commands.RegisterDeveloper
{
    public class RegisterDeveloperCommandHandler : IRequestHandler<RegisterDeveloperCommandRequest, LoginResponseDTO>
    {
        IDeveloperRepository _developerRepository;
        IUserRepository _userRepository;
        AuthBusinessRules _authBusinessRules;
        IMapper _mapper;
        IUserOperationClaimRepository _userOperationClaimRepository;
        ITokenHelper _tokenHelper;

        public RegisterDeveloperCommandHandler
            (
            IDeveloperRepository developerRepository,
            AuthBusinessRules authBusinessRules,
            IMapper mapper,
            IUserOperationClaimRepository userOperationClaimRepository,
            ITokenHelper tokenHelper,
            IUserRepository userRepository
            )
        {
            _developerRepository = developerRepository;
            _authBusinessRules = authBusinessRules;
            _mapper = mapper;
            _userOperationClaimRepository = userOperationClaimRepository;
            _tokenHelper = tokenHelper;
            _userRepository = userRepository;
        }

        public async Task<LoginResponseDTO> Handle(RegisterDeveloperCommandRequest request, CancellationToken cancellationToken)
        {
            await _authBusinessRules.EmailAddressCanNotBeDuplicated(request.Email);

            byte[] passwordHash;
            byte[] passwordSalt;
            HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);
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
            using TransactionScope transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            try
            {
                await _developerRepository.AddAsync(developer);
                await _userOperationClaimRepository.AddAsync(new UserOperationClaim(0, developer.Id, 2));

                AccessToken accessToken = _tokenHelper.CreateToken(developer, await _userRepository.GetOperationClaimsAsync(developer.Id));
                LoginResponseDTO loginResponseDTO = new() { AccessToken = accessToken };
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
