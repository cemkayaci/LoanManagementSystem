using LoanManagementSystem.Domain.Repositories.Loan.Contracts;
using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Domain.Repositories.Loan
{
    public class LoanRepositoriesFactory : ILoanRepositoriesFactory
    {
        public ILoanRepository NewLoanRepository(CosmosClient client) =>
            new LoanRepository(client);

    }
}
