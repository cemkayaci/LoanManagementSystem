using LoanManagementSystem.Common.Authentication;
using LoanManagementSystem.Common.HttpResponse;
using LoanManagementSystem.Common.Response;
using LoanManagementSystem.Common.Token;

namespace LoanManagementSystem.App.Services.User.Contracts
{
    public interface IUserService
    {
        public Task<Result<TokenModel>> Authenticate(UserAuthenticateModel model);

        public Task<bool> SignUp(UserAuthenticateModel model);

        public Task<bool> LogOut(string token);
    }
}
