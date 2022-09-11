using AutoMapper;
using Core.Security.DTOs;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using Devs.Application.Features.Auth.DTOs;
using Devs.Application.Features.Auth.Rules;
using Devs.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.Auth.Queries.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQueryRequest, LoginResponseDTO>
    {
        IUserRepository _userRepository;
        AuthBusinessRules _authBusinessRules;
        ITokenHelper _tokenHelper;

        public LoginQueryHandler
            (
            IUserRepository userRepository,
            AuthBusinessRules authBusinessRules,
            ITokenHelper tokenHelper
            )
        {
            _userRepository = userRepository;
            _authBusinessRules = authBusinessRules;
            _tokenHelper = tokenHelper;
        }

        public async Task<LoginResponseDTO> Handle(LoginQueryRequest request, CancellationToken cancellationToken)
        {
            User user = await _authBusinessRules.VerifyPassword(request.Email, request.Password);
            AccessToken accessToken = _tokenHelper.CreateToken(user, await _userRepository.GetOperationClaimsAsync(user.Id));
            LoginResponseDTO loginResponseDTO = new() { AccessToken = accessToken };
            return loginResponseDTO;
        }

    }
}
