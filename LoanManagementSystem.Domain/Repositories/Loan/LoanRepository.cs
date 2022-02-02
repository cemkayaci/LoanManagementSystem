using LoanManagementSystem.Common.DataModels.Loan;
using LoanManagementSystem.Domain.Repositories.Loan.Contracts;
using Microsoft.Azure.Cosmos;


namespace LoanManagementSystem.Domain.Repositories.Loan
{
    public class LoanRepository : CosmosBaseRepository<LoanModel>, ILoanRepository
    {
        public LoanRepository(CosmosClient client)
            : base(client) { }


        public async Task<LoanModel> CreateLoan(LoanModel loan)
        {
            loan.Id = Guid.NewGuid();

            ItemResponse<LoanModel> response = await Container.CreateItemAsync(loan);

            return response.Resource;
        }

        public async Task<IEnumerable<LoanModel>> GetAllLoans()
        {
            string sqlQuery = $"SELECT * FROM c";

            QueryDefinition query = new QueryDefinition(sqlQuery);

            FeedIterator<LoanModel> queryIterator = Container.GetItemQueryIterator<LoanModel>(query);

            FeedResponse<LoanModel> queryResult = await queryIterator.ReadNextAsync();

            return queryResult.Resource;
        }

        public async Task<LoanModel> GetLoanById(Guid loanId)
        {
            string sqlQuery = $"SELECT * FROM c WHERE c.id = '{loanId}'";

            QueryDefinition query = new QueryDefinition(sqlQuery);

            FeedIterator<LoanModel> queryIterator = Container.GetItemQueryIterator<LoanModel>(query);

            FeedResponse<LoanModel> queryResult = await queryIterator.ReadNextAsync();

            return queryResult.Resource.FirstOrDefault();
        }

        public async Task<LoanModel> UpdateLoan(LoanModel loan)
        {
            ItemResponse<LoanModel> response = await Container.ReplaceItemAsync(loan, loan.Id.ToString());
            return response.Resource;
        }
    }
}
