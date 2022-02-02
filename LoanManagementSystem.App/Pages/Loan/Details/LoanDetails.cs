using LoanManagementSystem.Common.DataModels.LoanDetails;
using Microsoft.AspNetCore.Components;

namespace LoanManagementSystem.App.Pages.Loan.Details
{
    public partial class LoanDetails
    {
        [Parameter]
        public List<LoanDetailModel> LoanDetailModelList { get; set; }

    }
}
