
using LoanManagementSystem.Common.DataModels.Loan;
using LoanManagementSystem.Common.DataModels.LoanDetails;


namespace LoanManagementSystem.Services.LoanDetails.Contracts
{
    public interface ILoanDetailsService
    {  
        Task<List<LoanDetailModel>> CalculateLoanDetails(LoanCalculationType calculationType, double sum, double interestPercentage, int term, int desiredMonthCalculation);   
    }
}
