using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoanManagementSystem.Calculations.Loan;
using LoanManagementSystem.Domain.DbConnectionFactory.Cosmos;
using LoanManagementSystem.Domain.DbConnectionFactory.Cosmos.Contracts;
using LoanManagementSystem.Domain.Repositories.Loan;
using LoanManagementSystem.Domain.Repositories.Loan.Contracts;
using LoanManagementSystem.Functions;
using LoanManagementSystem.Services.Loan;
using LoanManagementSystem.Services.Loan.Contracts;
using LoanManagementSystem.Services.LoanDetails;
using LoanManagementSystem.Services.LoanDetails.Contracts;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;


[assembly: FunctionsStartup(typeof(Startup))]
namespace LoanManagementSystem.Functions
{
    internal class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {                     
          
        }
    }
}
