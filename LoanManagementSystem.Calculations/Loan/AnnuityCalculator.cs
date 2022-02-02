using LoanManagementSystem.Calculations.KCalculator;
using LoanManagementSystem.Calculations.Loan.Contracts;
using LoanManagementSystem.Common.DataModels.Loan;
using LoanManagementSystem.Common.DataModels.LoanDetails;


namespace LoanManagementSystem.Calculations.Loan
{
    public class AnnuityCalculator : CalculationHelpers, ILoanCalculator
    {
        public LoanCalculationType CalculationType => LoanCalculationType.Annuity;

        public Func<double, double, int, LoanDetailModel> Calculate => (sum, interestPercentage, term) => 
        {
            var k1Calculated = new KFormulas(interestPercentage,term).GetK1Calculated;           
            var k3Calculated = new KFormulas(interestPercentage, term).GetK3Calculated;

            var balance = (base.PreviousBalance == 0) ? sum : (base.PreviousBalance - base.PreviousPayment);
            var interest = balance * k1Calculated;
            var total = sum * k3Calculated;
            var payment = total - interest;
            
            base.PreviousBalance = balance;
            base.PreviousPayment = payment;
            base.CurrentMonth += 1;

            return new LoanDetailModel()
            {
                Month = base.CurrentMonth,
                Balance = Math.Round(balance, 2),
                Interest = Math.Round(interest, 2),
                Payment = Math.Round(payment, 2),
                Total = Math.Round(total,2)                 
            };
        };        
    }
}
