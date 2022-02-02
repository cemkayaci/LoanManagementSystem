using LoanManagementSystem.Common.DataModels.LoanDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Calculations.Loan.Comparer
{
    public class LoanDetailsComparer : Comparer<LoanDetailModel>
    {    
        public override int Compare(LoanDetailModel? x, LoanDetailModel? y)
        {
            if (x.Month.CompareTo(y.Month) != 0)
            {
                return x.Month.CompareTo(y.Month);
            }
            else if (x.Balance.CompareTo(y.Balance) != 0)
            {
                return x.Balance.CompareTo(y.Balance);
            }
            else if (x.Interest.CompareTo(y.Interest) != 0)
            {
                return x.Interest.CompareTo(y.Interest);
            }
            else if (x.Payment.CompareTo(y.Payment) != 0)
            {
                return x.Payment.CompareTo(y.Payment);
            }
            else if (x.Total.CompareTo(y.Total) != 0)
            {
                return x.Total.CompareTo(y.Total);
            }
            else
            {
                return 0;
            }
        }
    }
}
