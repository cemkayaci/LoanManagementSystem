using LoanManagementSystem.App.Services.User.Contracts;
using LoanManagementSystem.Common.Authentication;
using LoanManagementSystem.Common.HttpResponse;
using LoanManagementSystem.Common.Response;
using LoanManagementSystem.Common.Token;
using System.Text;
using System.Text.Json;

namespace LoanManagementSystem.App.Services.User
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async  Task<Result<TokenModel>> Authenticate(UserAuthenticateModel model)   
        {
            var result = new Result<TokenModel>();
            try
            {

                var modelJson = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("/api/user/logIn", modelJson);

                if (response.IsSuccessStatusCode)
                {
                    result.IsSuccess = true;
                    result.response = await JsonSerializer.DeserializeAsync<TokenModel>(await response.Content.ReadAsStreamAsync(), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                }
            }
            catch (Exception ex)
            {

            }

            return result;

        }

        public Task<bool> LogOut(string token) =>
        Task.Run(async () =>
        {
            bool logOut = false;
            try
            {

                var modelJson = new StringContent(JsonSerializer.Serialize(token), Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("/api/user/logOut", modelJson);

                if (response.IsSuccessStatusCode)
                {
                    logOut = true;
                }
            }
            catch (Exception ex)
            {

            }
            return logOut = true;

        });

        public Task<bool> SignUp(UserAuthenticateModel model) =>
        Task.Run(async () =>
        {
            bool signUp = false;
            try
            {

                var modelJson = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("/api/user/add", modelJson);

                if (response.IsSuccessStatusCode)
                {
                    signUp = true;
                }
            }
            catch (Exception ex)
            {

            }

            return signUp;
        });
    }
}
