using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Common.DataModels.LoanDetails
{
    public class LoanDetailModel
    {        
        public int Month { get; set; }
        public double Balance { get; set; }
        public double Interest { get; set; }
        public double Payment { get; set; }
        public double Total { get; set; }

    }
}
