using LoanManagementSystem.App.Pages.Loan.Add;
using LoanManagementSystem.App.Services.Authentication.Contracts;
using LoanManagementSystem.App.Services.Loan.Contracts;
using LoanManagementSystem.Common.DataModels.Loan;
using LoanManagementSystem.Common.Response;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
namespace LoanManagementSystem.App.Services.Loan
{
    public class LoanService : ILoanService
    {
        private readonly HttpClient _httpClient;
        private readonly IAuthState authService;

        public LoanService(HttpClient httpClient,IAuthState authService)
        {
            _httpClient = httpClient;
            this.authService = authService;
        }

        public async Task<Result<LoanModel>> AddLoan(LoanModel loanModel)
        { 
            var result = new Result<LoanModel>();
            try
            {
               
                var loanJson = new StringContent(JsonSerializer.Serialize(loanModel), Encoding.UTF8, "application/json");
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", (await authService.GetToken()).Value);
                var response = await _httpClient.PostAsync("/api/loan/add", loanJson);

                if (response.IsSuccessStatusCode)
                {
                    result.IsSuccess = true;
                    result.response = await JsonSerializer.DeserializeAsync<LoanModel>(await response.Content.ReadAsStreamAsync(), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                }
            }catch (Exception ex)
            {

            }

            return result;
        }

        public async Task<Result<List<LoanModel>>> GetAllLoans()
        {
            var result = new Result<List<LoanModel>>();
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", (await authService.GetToken()).Value);
                var response = await _httpClient.GetAsync("/api/loan/getall");
                
                if (response.IsSuccessStatusCode)
                {
                    result.IsSuccess = true;
                    result.response = await JsonSerializer.DeserializeAsync<List<LoanModel>>(response.Content.ReadAsStream(), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                }
            }
            catch (Exception ex)
            {

            }
            return result;
        }


        public async Task<Result<LoanModel>> GetLoan(string loanId)
        {
            var result = new Result<LoanModel>();
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", (await authService.GetToken()).Value);
                var response = await _httpClient.GetAsync($"/api/loan/{loanId}");
                
                if (response.IsSuccessStatusCode)
                {
                    result.IsSuccess = true;
                    result.response = await JsonSerializer.DeserializeAsync<LoanModel>(response.Content.ReadAsStream(), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                }
            }catch (Exception ex)
            {

            }
            return result;
        }

        public async Task<Result<LoanModel>> UpdateLoan(LoanModel loanModel)
        {
            var result = new Result<LoanModel>();
            try
            {

                var loanJson = new StringContent(JsonSerializer.Serialize(loanModel), Encoding.UTF8, "application/json");
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", (await authService.GetToken()).Value);
                var response = await _httpClient.PutAsync("api/loan/update", loanJson);

                if (response.IsSuccessStatusCode)
                {
                    result.IsSuccess = true;
                    result.response = await JsonSerializer.DeserializeAsync<LoanModel>(await response.Content.ReadAsStreamAsync(), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                }
            }
            catch (Exception ex)
            {

            }

            return result;
        }
    }
}
