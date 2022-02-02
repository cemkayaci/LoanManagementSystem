using LoanManagementSystem.App.Services.Authentication.Contracts;
using LoanManagementSystem.App.Services.Loan.Contracts;
using LoanManagementSystem.Common.DataModels.Loan;
using LoanManagementSystem.Common.Response;
using Microsoft.AspNetCore.Components;

namespace LoanManagementSystem.App.Pages.Loan.Edit
{
    public partial class EditLoan
    {

        [Parameter]
        public string LoanId { get; set; }
        public LoanModel LoanModel = new LoanModel();
        [Inject]
        public ILoanService LoanService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IAuthState Auth { get; set; }
         
        protected async override Task OnInitializedAsync()
        {
            if (!(await Auth.IsAuthorized()))
            {
                NavigationManager.NavigateTo("/login");
            }

            Result<LoanModel> loan = await LoanService.GetLoan(LoanId);
            if (loan.IsSuccess)
            {
                LoanModel = loan.response;
            }
            else
            {
                StatusClass = "alert-danger";
                Message = "Something went wrong retrieveing the loan. Please try again.";
            }
        }
        protected string StatusClass = string.Empty;
        protected bool Saved;
        protected string Message = string.Empty;
        protected async Task HandleValidSubmit()
        {
            Saved = false;
            var result = await LoanService.UpdateLoan(LoanModel);
            if (result.IsSuccess)
            {
                Saved = true;
                NavigationManager.NavigateTo("/loans");
            }
            else
            {
                StatusClass = "alert-danger";
                Message = "Something went wrong updating the loan. Please try again.";
            }

        }
        protected void NavigateToMain()
        {
            NavigationManager.NavigateTo("/");
        }
    }
}
