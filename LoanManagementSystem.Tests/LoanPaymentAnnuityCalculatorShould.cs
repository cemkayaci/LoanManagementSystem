using LoanManagementSystem.Calculations.Loan;
using LoanManagementSystem.Calculations.Loan.Comparer;
using LoanManagementSystem.Calculations.Loan.Contracts;
using LoanManagementSystem.Common.DataModels.Loan;
using LoanManagementSystem.Common.DataModels.LoanDetails;
using LoanManagementSystem.Services.LoanDetails;
using LoanManagementSystem.Services.LoanDetails.Contracts;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Tests
{
     
    public class LoanPaymentAnnuityCalculatorShould  
    {
        
        

        [Test]
        [TestCase(LoanCalculationType.Annuity, 10000,5,36,5)]
        public void Calculate5thMonthRepaymentwith36TermAnd5Interest(LoanCalculationType type,
                                                                     double sum, 
                                                                     double interestPercentage,
                                                                     int term,
                                                                     int desiredMonthCalculation)
        {
            LoanDetailsService loanDetailsService = Setup();
            var result = loanDetailsService.CalculateLoanDetails(type, sum, interestPercentage, term, desiredMonthCalculation).Result;

            Assert.IsNotNull(result);

            var loanDetailsComparer = new LoanDetailsComparer();
            var fifthMonthRepayment = new LoanDetailModel() { Month = 5, Balance = 8961.36, Interest = 37.34, Payment = 262.37, Total = 299.71 };

            var last = result.LastOrDefault();
            Assert.That(last, Is.EqualTo(fifthMonthRepayment).Using<LoanDetailModel>(loanDetailsComparer));
            Assert.That(result, Has.Exactly(desiredMonthCalculation).Items);        
             
        }

        [TestCase(LoanCalculationType.Annuity, 20000, 8, 48, 8)]
        public void Calculate8thMonthRepaymentwith48TermAnd8Interest(LoanCalculationType type,
                                                                     double sum,
                                                                     double interestPercentage,
                                                                     int term,
                                                                     int desiredMonthCalculation)
        {
            LoanDetailsService loanDetailsService = Setup();
            var result = loanDetailsService.CalculateLoanDetails(type, sum, interestPercentage, term, desiredMonthCalculation).Result;

            Assert.IsNotNull(result);

            var loanDetailsComparer = new LoanDetailsComparer();
            var fifthMonthRepayment = new LoanDetailModel() { Month = 8, Balance = 17465.28,Interest = 116.44,Payment = 371.82,Total = 488.26};


            Assert.That(result.LastOrDefault(), Is.EqualTo(fifthMonthRepayment).Using<LoanDetailModel>(loanDetailsComparer));
            Assert.That(result, Has.Exactly(desiredMonthCalculation).Items);
        }
        [TestCase(LoanCalculationType.Annuity, 30000, 10, 60, 10)]
        public void Calculate8thMonthRepaymentwith60TermAnd10Interest(LoanCalculationType type,
                                                                     double sum,
                                                                     double interestPercentage,
                                                                     int term,
                                                                     int desiredMonthCalculation)
        {
            LoanDetailsService loanDetailsService = Setup();
            var result = loanDetailsService.CalculateLoanDetails(type, sum, interestPercentage, term, desiredMonthCalculation).Result;

            Assert.IsNotNull(result);

            var loanDetailsComparer = new LoanDetailsComparer();
            var fifthMonthRepayment = new LoanDetailModel() { Month = 10, Balance = 26394.79,Interest = 219.96,Payment = 417.45, Total = 637.41};
            Assert.That(result.LastOrDefault(), Is.EqualTo(fifthMonthRepayment).Using<LoanDetailModel>(loanDetailsComparer));
            Assert.That(result, Has.Exactly(desiredMonthCalculation).Items);
        }

        public LoanDetailsService Setup()
        {
            var enabledCalculations = new EnabledCalculations();
            LoanDetailsService loanDetailsService = new LoanDetailsService(enabledCalculations);
            return loanDetailsService;
        }

    }
}
