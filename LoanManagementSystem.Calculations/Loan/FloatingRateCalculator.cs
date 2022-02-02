using LoanManagementSystem.Calculations.KCalculator;
using LoanManagementSystem.Calculations.Loan.Contracts;
using LoanManagementSystem.Common.DataModels.Loan;
using LoanManagementSystem.Common.DataModels.LoanDetails;


namespace LoanManagementSystem.Calculations.Loan
{
    public class FloatingRateCalculator : CalculationHelpers, ILoanCalculator
    {
        public LoanCalculationType CalculationType => LoanCalculationType.FloatingRate;

        public Func<double, double, int, LoanDetailModel> Calculate => (sum, interestPercentage, term) =>
        {
            base.CurrentMonth += 1;

            if (base.CurrentMonth > 3 && base.CurrentMonth % 3 == 1)
            {
                base.CurrentInterestPercentage += 0.25;
            }            

            var k1Calculated = new KFormulas(interestPercentage, term).GetK1Calculated;

            var balance = (base.PreviousBalance == 0) ? sum : (base.PreviousBalance - base.PreviousPayment);
            var interest = (balance * ((interestPercentage- CurrentInterestPercentage)/100))/12;
            var payment = sum / term;
            var total = interest + payment;
            
            base.PreviousBalance = balance;
            base.PreviousPayment = payment;           


            return new LoanDetailModel()
            {
                Month = base.CurrentMonth,
                Balance = Math.Round(balance, 2),
                Interest = Math.Round(interest, 2),
                Payment = Math.Round(payment, 2),
                Total = Math.Round(total, 2)
            };
        };
    }
}
