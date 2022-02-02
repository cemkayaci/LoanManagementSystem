using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Domain.Context
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<LoansDbContext>
    {
        public LoansDbContext CreateDbContext(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder()
           .AddJsonFile("appsettings.json", true, true)
           .Build();
            var builder = new DbContextOptionsBuilder<LoansDbContext>();
            var connectionString = config.GetConnectionString("SqlServerConnectionString");
            builder.UseSqlServer(connectionString);
            return new LoansDbContext(builder.Options);
        }
    }
}
