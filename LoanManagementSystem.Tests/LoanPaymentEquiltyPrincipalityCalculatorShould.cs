using LoanManagementSystem.Calculations.Loan;
using LoanManagementSystem.Calculations.Loan.Comparer;
using LoanManagementSystem.Common.DataModels.Loan;
using LoanManagementSystem.Common.DataModels.LoanDetails;
using LoanManagementSystem.Services.LoanDetails;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Tests
{
    
    public class LoanPaymentEquiltyPrincipalityCalculatorShould
    {

        

        [Test]
        [TestCase(LoanCalculationType.EqualPrincipality, 10000, 5,36,5)]
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
            var fifthMonthRepayment = new LoanDetailModel() { Month = 5, Balance = 8888.89, Interest = 37.04, Payment = 277.78, Total = 314.81 };


            Assert.That(result.LastOrDefault(), Is.EqualTo(fifthMonthRepayment).Using<LoanDetailModel>(loanDetailsComparer));
            Assert.That(result, Has.Exactly(desiredMonthCalculation).Items);

        }

        [TestCase(LoanCalculationType.EqualPrincipality, 20000, 8, 48, 8)]
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
            var fifthMonthRepayment = new LoanDetailModel() { Month = 8, Balance = 17083.33,Interest = 113.89,Payment = 416.67,Total = 530.56};


            Assert.That(result.LastOrDefault(), Is.EqualTo(fifthMonthRepayment).Using<LoanDetailModel>(loanDetailsComparer));
            Assert.That(result, Has.Exactly(desiredMonthCalculation).Items);
        }
        [TestCase(LoanCalculationType.EqualPrincipality, 30000, 10, 60, 10)]
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
            var fifthMonthRepayment = new LoanDetailModel() { Month = 10, Balance = 25500.00,Interest = 212.50,Payment = 500.00,Total = 712.50};


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
