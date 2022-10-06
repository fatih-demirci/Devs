using Core.Persistence.Repositories;
using Core.Security.Entities;
using Devs.Application.Services.Repositories;
using Devs.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core.CustomTypeProviders;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Persistence.Repositories
{
    public class UserRepository : EfRepositoryBase<User, DevsWriteContext, DevsReadContext>, IUserRepository
    {
        public UserRepository(DevsWriteContext devsWriteContext, DevsReadContext devsReadContext) : base(devsWriteContext, devsReadContext)
        {

        }
    }
}
