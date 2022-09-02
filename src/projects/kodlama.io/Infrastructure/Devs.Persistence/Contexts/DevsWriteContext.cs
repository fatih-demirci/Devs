using Devs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Persistence.Contexts
{
    public class DevsWriteContext : DevsBaseContext<DevsWriteContext>
    {
        public DevsWriteContext(DbContextOptions<DevsWriteContext> dbContextOptions, IConfiguration configuration) : base(dbContextOptions, configuration)
        {
        }
    }
}
