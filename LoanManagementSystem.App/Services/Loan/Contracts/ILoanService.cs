using LoanManagementSystem.Common.DataModels.Loan;
using LoanManagementSystem.Common.Response;

namespace LoanManagementSystem.App.Services.Loan.Contracts
{
    public interface ILoanService
    {
        Task<Result<LoanModel>> AddLoan(LoanModel loanModel);
        Task<Result<LoanModel>> GetLoan(string loanId);
        Task<Result<List<LoanModel>>> GetAllLoans();

        Task<Result<LoanModel>> UpdateLoan(LoanModel loanModel);
    }
}
