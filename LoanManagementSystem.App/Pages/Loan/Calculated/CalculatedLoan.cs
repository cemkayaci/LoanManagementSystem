using LoanManagementSystem.App.Services.Authentication.Contracts;
using LoanManagementSystem.App.Services.Loan.Contracts;
using LoanManagementSystem.Common.DataModels.Loan;
using Microsoft.AspNetCore.Components;

namespace LoanManagementSystem.App.Pages.Loan.Calculated
{
    public partial class CalculatedLoan
    {
        [Parameter]
        public string LoanId { get; set; }
        [Inject]
        public ILoanService LoanService { get; set; }
        [Inject]
        public IAuthState Auth { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public LoanModel LoanModel { get; set; }

        protected string StatusClass = string.Empty;
        protected bool IsSuccess;
        protected string Message = string.Empty;

        protected async override Task OnInitializedAsync()
        {
            if (!(await Auth.IsAuthorized()))
            {
                NavigationManager.NavigateTo("/login");
            }

            IsSuccess = false;
            var result = await LoanService.GetLoan(LoanId);
            if (result.IsSuccess)
            {
                IsSuccess = true;
                LoanModel = result.response;
            }
            else
            {
                StatusClass = "alert-danger";
                Message = "Something went wrong during retrieving data. Please try again.";
            }
        }
    }
}
