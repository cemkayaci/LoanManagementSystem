using LoanManagementSystem.Common.DataModels.Loan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Calculations.Loan.Comparer
{
    public class LoanComparer : Comparer<LoanModel>
    {
        public override int Compare(LoanModel? x, LoanModel? y)
        {
            if (x.Customer.CompareTo(y.Customer) != 0)
            {
                return x.Customer.CompareTo(y.Customer);
            }
            else if (x.Sum.CompareTo(y.Sum) != 0)
            {
                return x.Sum.CompareTo(y.Sum);
            }
            else if (x.InterestPercentage.CompareTo(y.InterestPercentage) != 0)
            {
                return x.InterestPercentage.CompareTo(y.InterestPercentage);
            }
            else if (x.LoanCalculationType.CompareTo(y.LoanCalculationType) != 0)
            {
                return x.LoanCalculationType.CompareTo(y.LoanCalculationType);
            }
            else if (x.Months.CompareTo(y.Months) != 0)
            {
                return x.Months.CompareTo(y.Months);
            }
            else
            {
                return 0;
            }            
        }
    }

    // var xInFahrenheit = x.Format == TemperatureFormat.Fahrenheit ? x.Amount : x.ToFahrenheit();
    //var yInFahrenheit = y.Format == TemperatureFormat.Fahrenheit ? y.Amount : y.ToFahrenheit();

      //  return Comparer<decimal>.Default.Compare(xInFahrenheit, yInFahrenheit);
}
