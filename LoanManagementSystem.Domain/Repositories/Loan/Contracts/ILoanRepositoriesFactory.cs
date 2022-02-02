using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Domain.Repositories.Loan.Contracts
{
    public interface ILoanRepositoriesFactory
    {
        ILoanRepository NewLoanRepository(CosmosClient client);
    }
}
