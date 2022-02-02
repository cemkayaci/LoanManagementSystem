using LoanManagementSystem.App.Services.Authentication.Contracts;
using LoanManagementSystem.App.Services.Loan.Contracts;
using LoanManagementSystem.Common.DataModels.Loan;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;

namespace LoanManagementSystem.App.Pages.Loan.List
{
    public partial class LoansList 
    {
        private HubConnection _hubConnection;

        [Inject]
        public ILoanService LoanService { get; set; }
        public List<LoanModel> LoanModels { get; set;}
        [Inject]
        public IAuthState Auth { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

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
            var result = await LoanService.GetAllLoans();
            if (result.IsSuccess)
            {
                IsSuccess = true;
                LoanModels = result.response;
            }
            else
            {
                StatusClass = "alert-danger";
                Message = "Something went wrong during retrieving data. Please try again.";
            }

            await StartHubConnection();           
        }
         

        private async Task StartHubConnection()
        {
            _hubConnection = new HubConnectionBuilder()
                .WithUrl("http://localhost:7071/api")
                .WithAutomaticReconnect()
                .Build();

            _hubConnection.On<LoanModel>("target", (data) =>
            {
                var loanFound = LoanModels.FirstOrDefault(item => item.Id == data.Id);
                if (loanFound !=null){                   
                    LoanModels.Remove(loanFound);
                }
                LoanModels.Add(data);
                StateHasChanged();
            });

            await _hubConnection.StartAsync();
        }

        public void Dispose()
        {
            _hubConnection.DisposeAsync();
        }
    }
}
