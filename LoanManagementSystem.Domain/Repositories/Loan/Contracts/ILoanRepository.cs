using LoanManagementSystem.Common.DataModels.Loan;

namespace LoanManagementSystem.Domain.Repositories.Loan.Contracts
{
    public interface ILoanRepository
    {
        Task<LoanModel> CreateLoan(LoanModel loan);
        Task<IEnumerable<LoanModel>> GetAllLoans();
        Task<LoanModel> GetLoanById(Guid loanId);
        Task<LoanModel> UpdateLoan(LoanModel loan);        
            
    }
}