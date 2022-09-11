using Core.Security.Entities;
using Core.Security.Enums;
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
    public class DevsBaseContext<TContext> : DbContext
        where TContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
        public DbSet<ProgrammingLanguageTechnology> ProgrammingLanguageTechnologies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }

        public DevsBaseContext(DbContextOptions<TContext> dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProgrammingLanguage>(pl =>
            {
                pl.ToTable("ProgrammingLanguages").HasKey(k => k.Id);
                pl.Property(p => p.Id).HasColumnName("Id");
                pl.Property(p => p.Name).HasColumnName("Name");

                pl.HasMany(pl => pl.ProgrammingLanguageTechnologies);
            });

            ProgrammingLanguage[] programmingLanguages = { new(1, "C#"), new(2, "Java") };
            modelBuilder.Entity<ProgrammingLanguage>().HasData(programmingLanguages);


            modelBuilder.Entity<ProgrammingLanguageTechnology>(plt =>
            {
                plt.ToTable("ProgrammingLanguageTechnologies").HasKey(k => k.Id);
                plt.Property(p => p.Id).HasColumnName("Id");
                plt.Property(p => p.ProgrammingLanguageId).HasColumnName("ProgrammingLanguageId");
                plt.Property(p => p.Name).HasColumnName("Name");

                plt.HasOne(plt => plt.ProgrammingLanguage);
            });

            ProgrammingLanguageTechnology[] programmingLanguageTechnologies = { new(1, 1, ".NET"), new(2, 1, "WPF"), new(3, 2, "Spring"), new(4, 2, "JSP") };
            modelBuilder.Entity<ProgrammingLanguageTechnology>().HasData(programmingLanguageTechnologies);

            modelBuilder.Entity<User>(u =>
            {
                u.ToTable("Users").HasKey(k => k.Id);
                u.Property(p => p.Id).HasColumnName("Id");
                u.Property(p => p.Email).HasColumnName("Email");
                u.Property(p => p.Name).HasColumnName("Name");
                u.Property(p => p.PasswordHash).HasColumnName("PasswordHash");
                u.Property(p => p.PasswordSalt).HasColumnName("PasswordSalt");
                u.Property(p => p.AuthenticatorType).HasColumnName("AuthenticatorType");
                u.Property(p => p.Status).HasColumnName("Status");

                u.HasMany(u => u.UserOperationClaims);
            });


            modelBuilder.Entity<UserOperationClaim>(uoc =>
            {
                uoc.ToTable("UserOperationClaims").HasKey(k => k.Id);
                uoc.Property(p => p.Id).HasColumnName("Id");
                uoc.Property(p => p.UserId).HasColumnName("UserId");
                uoc.Property(u => u.OperationClaimId).HasColumnName("OperationClaimId");

                uoc.HasOne(uoc => uoc.OperationClaim);
                uoc.HasOne(uoc => uoc.User);
            });

            modelBuilder.Entity<OperationClaim>(oc =>
            {
                oc.ToTable("OperationClaims").HasKey(k => k.Id);
                oc.Property(p => p.Id).HasColumnName("Id");
                oc.Property(p => p.Name).HasColumnName("Name");

                OperationClaim[] operationClaims = { new(1, "admin"), new(2, "developer") };
                modelBuilder.Entity<OperationClaim>().HasData(operationClaims);
            });

        }
    }
}
