



using LoanManagementSystem.Common.DataModels.Loan;

namespace LoanManagementSystem.Services.Loan.Contracts
{
    public interface ILoanService
    {
        Task<LoanModel> CreateLoan(LoanModel loan);
        Task<IEnumerable<LoanModel>> GetAllLoans();
        Task<LoanModel> GetLoanById(Guid loanId);
        Task<LoanModel> UpdateLoan(LoanModel loan);
    }
}
