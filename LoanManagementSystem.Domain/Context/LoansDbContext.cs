using LoanManagementSystem.Domain.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Domain.Context
{
    public class LoansDbContext : IdentityDbContext<User>
    {
        private readonly IConfiguration _configuration;

        public LoansDbContext(DbContextOptions options) : base(options)
        {
        }
       
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            EntityTypeBuilder<User> user = builder.Entity<User>();
            user.Property(e => e.Id).HasColumnName("ID");
            user.Property(e => e.Name).HasMaxLength(100);
            user.Property(e => e.TokenExpires).HasDefaultValue(default(DateTime));
        }
    }
}
