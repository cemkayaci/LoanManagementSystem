

using LoanManagementSystem.Calculations.Loan.Contracts;

namespace LoanManagementSystem.Calculations.Loan
{
    public class EnabledCalculations
    {
        public List<ILoanCalculator> LoanCalculators = new List<ILoanCalculator>()
        {
            new AnnuityCalculator(),
            new EqualPrincipalityCalculator(),
            new FloatingRateCalculator()
        };
    }
}
