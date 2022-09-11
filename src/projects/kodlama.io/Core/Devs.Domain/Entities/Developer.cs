using Core.Security.Entities;
using Core.Security.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Domain.Entities
{
    public class Developer : User
    {
        public string GithubURL { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Developer(string firstName, string lastName) : base($"{firstName} {lastName}")
        {

        }

        public Developer
            (
            int id,
            string githubURL,
            string firstName,
            string lastName,
            string email,
            byte[] passwordSalt,
            byte[] passwordHash,
            bool status,
            AuthenticatorType authenticatorType,
            ICollection<UserOperationClaim> userOperationClaims,
            ICollection<RefreshToken> refreshTokens
            ) : base($"{firstName} {lastName}")
        {
            Id = id;
            GithubURL = githubURL;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PasswordSalt = passwordSalt;
            PasswordHash = passwordHash;
            Status = status;
            AuthenticatorType = authenticatorType;
            UserOperationClaims = userOperationClaims;
            RefreshTokens = refreshTokens;
        }
    }
}
