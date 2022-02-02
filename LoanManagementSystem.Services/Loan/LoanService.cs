


using LoanManagementSystem.Common.DataModels.Loan;
using LoanManagementSystem.Domain.DbConnectionFactory.Cosmos.Contracts;
using LoanManagementSystem.Domain.Repositories.Loan.Contracts;
using LoanManagementSystem.Services.Loan.Contracts;
using LoanManagementSystem.Services.LoanDetails;
using LoanManagementSystem.Services.LoanDetails.Contracts;
using Microsoft.Azure.Cosmos;

namespace LoanManagementSystem.Services.Loan
{
    public class LoanService : ILoanService
    {
        private readonly ICosmosDbClientFactory _cosmosDbClientFactory;
        private readonly ILoanRepositoriesFactory _loanRepositoriesFactory;
        private readonly ILoanDetailsService _loanDetailsService;

        public LoanService(ICosmosDbClientFactory cosmosDbClientFactory,
                           ILoanRepositoriesFactory loanRepositoriesFactory,
                           ILoanDetailsService loanDetailsService)
        {
            _cosmosDbClientFactory = cosmosDbClientFactory;
            _loanRepositoriesFactory = loanRepositoriesFactory;
            _loanDetailsService = loanDetailsService;
        }

        public Task<LoanModel> CreateLoan(LoanModel loan) =>
        Task.Run(async () =>
        {
            using (CosmosClient client = _cosmosDbClientFactory.NewCosmosClient()){
                ILoanRepository loanRepository = _loanRepositoriesFactory.NewLoanRepository(client);

                var loanDetails = await _loanDetailsService.CalculateLoanDetails(loan.LoanCalculationType, loan.Sum, loan.InterestPercentage, loan.Months, loan.Months);

                loan.LoanDetails.AddRange(loanDetails);

                return await loanRepository.CreateLoan(loan);
            }
            
        });

        public Task<IEnumerable<LoanModel>> GetAllLoans() =>
        Task.Run(async () =>
        {
            using(CosmosClient client = _cosmosDbClientFactory.NewCosmosClient()){
                ILoanRepository loanRepository = _loanRepositoriesFactory.NewLoanRepository(client);
                return await loanRepository.GetAllLoans();
            }
        });

        public async Task<LoanModel> GetLoanById(Guid loanId)
        {
            using (CosmosClient client = _cosmosDbClientFactory.NewCosmosClient())
            {
                ILoanRepository loanRepository = _loanRepositoriesFactory.NewLoanRepository(client);
                return await loanRepository.GetLoanById(loanId);
            }
        }

        public Task<LoanModel> UpdateLoan(LoanModel loan) =>
        Task.Run(async () =>
        {
            using (CosmosClient client = _cosmosDbClientFactory.NewCosmosClient())
            {
               
                loan.LoanDetails.Clear();
                var loanDetails = await _loanDetailsService.CalculateLoanDetails(loan.LoanCalculationType, loan.Sum, loan.InterestPercentage, loan.Months, loan.Months);
                loan.LoanDetails.AddRange(loanDetails);

                ILoanRepository loanRepository = _loanRepositoriesFactory.NewLoanRepository(client);
                return await loanRepository.UpdateLoan(loan);
            }
        });
    }
}
