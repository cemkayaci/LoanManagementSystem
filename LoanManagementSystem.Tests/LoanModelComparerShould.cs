using LoanManagementSystem.Common.DataModels.Loan;
using NUnit.Framework;
using LoanManagementSystem.Calculations.Loan.Comparer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LoanManagementSystem.Tests
{
    internal class LoanModelComparerShould
    {
        [Test]
        public void ValueEquality()
        {

            var a = new LoanModel();
            a.Months = 1;
            a.Customer = "Nolt Technologies";
            a.InterestPercentage = 4;
            a.Sum = 5;
            a.LoanCalculationType = LoanCalculationType.Annuity;

            var b = new LoanModel();
            b.Months = 1;
            b.Customer = "Nolt Technologies";
            b.InterestPercentage = 4;
            b.Sum = 5;
            b.LoanCalculationType = LoanCalculationType.Annuity;

            var loanDetailsComparer = new LoanComparer();
            Assert.That(a, Is.EqualTo(b).Using<LoanModel>(loanDetailsComparer));
        }


        [Test]
        public void ValueInequality()
        {
            var a = new LoanModel();
            a.Months = 2;
            a.Customer = "Nolt Technologies";
            a.InterestPercentage = 4;
            a.Sum = 5;
            a.LoanCalculationType = LoanCalculationType.Annuity;

            var b = new LoanModel();
            b.Months = 1;
            b.Customer = "Nolt Technologies";
            b.InterestPercentage = 4;
            b.Sum = 1;
            b.LoanCalculationType = LoanCalculationType.FloatingRate;

            var loanDetailsComparer = new LoanComparer();
            Assert.That(a, Is.Not.EqualTo(b).Using<LoanModel>(loanDetailsComparer));
        }
    }
}
