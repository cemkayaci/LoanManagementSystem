using LoanManagementSystem.Calculations.Loan.Comparer;
using LoanManagementSystem.Common.DataModels.LoanDetails;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Tests
{
    public  class LoanDetailModelComparerShould
    {
        [Test]
        public void ValueEquality()
        {
         
            var a = new LoanDetailModel();
            a.Month  = 1;
            a. Balance  = 3;
            a. Interest = 4;
            a.Payment = 5;
            a.Total = 10;

            var b = new LoanDetailModel();
            b.Month = 1;
            b.Balance = 3;
            b.Interest = 4;
            b.Payment = 5;
            b.Total = 10;

            var loanDetailsComparer = new LoanDetailsComparer();
            Assert.That(a, Is.EqualTo(b).Using<LoanDetailModel>(loanDetailsComparer));
        }


        [Test]
        public void ValueInequality()
        {
            var a = new LoanDetailModel();
            a.Month = 1;
            a.Balance = 3;
            a.Interest = 4;
            a.Payment = 5;
            a.Total = 10;

            var b = new LoanDetailModel();
            b.Month = 2;
            b.Balance = 3;
            b.Interest = 4;
            b.Payment = 5;
            b.Total = 12;

            var loanDetailsComparer = new LoanDetailsComparer();
            Assert.That(a, Is.Not.EqualTo(b).Using<LoanDetailModel>(loanDetailsComparer));
        }
    }
}
