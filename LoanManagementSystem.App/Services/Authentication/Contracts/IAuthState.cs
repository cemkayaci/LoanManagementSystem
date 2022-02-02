using LoanManagementSystem.Common.Cookie;
using LoanManagementSystem.Common.Token;

namespace LoanManagementSystem.App.Services.Authentication.Contracts
{
    public interface IAuthState
    {
        public event Action<bool> OnAuthStateChanged;

        public Task LogIn(TokenModel tokenWithExpireDate);

        public Task LogOut();

        public Task<CookieModel> GetToken();

        public Task<bool> IsAuthorized();
    }
}
