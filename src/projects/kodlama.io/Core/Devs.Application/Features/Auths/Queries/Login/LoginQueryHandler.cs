using AutoMapper;
using Core.Security.DTOs;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using Devs.Application.Features.Auths.DTOs;
using Devs.Application.Features.Auths.Rules;
using Devs.Application.Services.AuthServices;
using Devs.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.Auths.Queries.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQueryRequest, LoginResponseDTO>
    {
        IUserRepository _userRepository;
        AuthBusinessRules _authBusinessRules;
        IAuthService _authService;

        public LoginQueryHandler
            (
            IUserRepository userRepository,
            AuthBusinessRules authBusinessRules,
            IAuthService authService
            )
        {
            _userRepository = userRepository;
            _authBusinessRules = authBusinessRules;
            _authService = authService;
        }

        public async Task<LoginResponseDTO> Handle(LoginQueryRequest request, CancellationToken cancellationToken)
        {
            User user = await _authBusinessRules.VerifyPassword(request.Email, request.Password);
            AccessToken accessToken = await _authService.CreateAccessToken(user);
            RefreshToken refreshToken = await _authService.CreateRefreshToken(user, request.IpAddress);
            LoginResponseDTO loginResponseDTO = new() { AccessToken = accessToken, RefreshToken = refreshToken };
            return loginResponseDTO;
        }

    }
}
