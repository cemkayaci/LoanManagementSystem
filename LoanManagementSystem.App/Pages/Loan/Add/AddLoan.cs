using LoanManagementSystem.App.Services.Authentication.Contracts;
using LoanManagementSystem.App.Services.Loan.Contracts;
using LoanManagementSystem.Common.DataModels.Loan;
using Microsoft.AspNetCore.Components;

namespace LoanManagementSystem.App.Pages.Loan.Add
{
    public partial class AddLoan
    {
        public LoanModel LoanModel = new LoanModel();
        [Inject]
        public ILoanService LoanService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IAuthState Auth { get; set; }

        protected string StatusClass = string.Empty;
        protected bool Saved;
        protected string Message = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            if (!(await Auth.IsAuthorized()))
            {
                NavigationManager.NavigateTo("/login");
            }
        }

        protected async Task HandleValidSubmit()
        {
            Saved = false;
            var result = await LoanService.AddLoan(LoanModel);
            if (result.IsSuccess)
            {
                Saved = true;
                NavigationManager.NavigateTo($"/loan/calculated/{result.response.Id}");
            }
            else
            {
                StatusClass = "alert-danger";
                Message = "Something went wrong adding the new loan. Please try again.";
            }            
        }

        protected void NavigateToMain()
        {
            NavigationManager.NavigateTo("/");
        }
    }
}
