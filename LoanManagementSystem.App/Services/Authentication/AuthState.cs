using LoanManagementSystem.App.Services.Authentication.Contracts;
using LoanManagementSystem.App.Services.Cookie.Contracts;
using LoanManagementSystem.Common.Cookie;
using LoanManagementSystem.Common.Token;

namespace LoanManagementSystem.App.Services.Authentication
{
    public class AuthState : IAuthState
    {
        private const string AUTHORIZE_TOKEN_COOKIE_NAME = "token";

        private ICookieHelper _cookieHelper;

        public event Action<bool> OnAuthStateChanged;

        public AuthState(ICookieHelper cookieHelper)
        {
            _cookieHelper = cookieHelper;
        }

        public async Task LogIn(TokenModel tokenWithExpireDate)
        {
            await _cookieHelper.AddCookie(AUTHORIZE_TOKEN_COOKIE_NAME, tokenWithExpireDate.Token, tokenWithExpireDate.ExpireTime);

            OnAuthStateChanged?.Invoke(true);
        }

        public async Task LogOut()
        {
            await _cookieHelper.Clear(AUTHORIZE_TOKEN_COOKIE_NAME);

            OnAuthStateChanged?.Invoke(false);
        }

        public Task<CookieModel> GetToken()
        {
            return _cookieHelper.GetCookieValue(AUTHORIZE_TOKEN_COOKIE_NAME);
        }

        public async Task<bool> IsAuthorized()
        {
            return (await _cookieHelper.GetCookieValue(AUTHORIZE_TOKEN_COOKIE_NAME)).Present;
        }
    }
}
