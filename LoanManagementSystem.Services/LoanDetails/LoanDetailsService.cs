

using LoanManagementSystem.Calculations.Loan;
using LoanManagementSystem.Common.DataModels.Loan;
using LoanManagementSystem.Common.DataModels.LoanDetails;
using LoanManagementSystem.Services.LoanDetails.Contracts;


namespace LoanManagementSystem.Services.LoanDetails
{
    public class LoanDetailsService : ILoanDetailsService
    {
        private readonly EnabledCalculations _enabledCalculations;     

        public LoanDetailsService(EnabledCalculations enabledCalculations)
        {
            _enabledCalculations = enabledCalculations;           
        }

        public Task<List<LoanDetailModel>> CalculateLoanDetails(LoanCalculationType calculationType, double sum, double interestPercentage, int term, int desiredMonthCalculation) =>
        Task.Run(() =>
        {
              List<LoanDetailModel> loanDetails = new List<LoanDetailModel>();

              var calculateLoanLine = _enabledCalculations.LoanCalculators.Where(t => t.CalculationType == calculationType)
              .Select(t => t.Calculate).FirstOrDefault();
              
              for (int i=0; i< desiredMonthCalculation; i++)
              {
                  var loanDetail = calculateLoanLine(sum, interestPercentage, term);
                  loanDetails.Add(loanDetail);
              }

              return loanDetails;
        });

    }
}
