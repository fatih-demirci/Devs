using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Core.Security.Hashing;
using Devs.Application.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.Auths.Rules
{
    public class AuthBusinessRules
    {
        IUserRepository _userRepository;

        public AuthBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> VerifyPassword(string email, string password)
        {
            User? user = await _userRepository.GetAsync(u => u.Email == email);
            if (user == null) throw new BusinessException("Email address does not exists.");
            if (!HashingHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                throw new BusinessException("Password incorrect");
            return user;
        }

        public async Task EmailAddressCanNotBeDuplicated(string email)
        {
            User? user = await _userRepository.GetAsync(u => u.Email == email);
            if (user != null) throw new BusinessException("Email address exists");
        }
    }
}