using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Calculations.Loan
{
    public class CalculationHelpers
    {
        public int CurrentMonth { get; set; } = 0;
        public double CurrentInterestPercentage  { get; set; } = 0;
        public double PreviousBalance { get; set; } = 0;
        public double PreviousPayment { get; set; } = 0;
    }
}
