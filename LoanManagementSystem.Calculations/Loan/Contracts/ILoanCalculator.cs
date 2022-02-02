



using LoanManagementSystem.Common.DataModels.Loan;
using LoanManagementSystem.Common.DataModels.LoanDetails;

namespace LoanManagementSystem.Calculations.Loan.Contracts
{
    public interface ILoanCalculator
    {
        public LoanCalculationType CalculationType { get; }
        Func<double, double, int, LoanDetailModel> Calculate { get; }
    }
}
