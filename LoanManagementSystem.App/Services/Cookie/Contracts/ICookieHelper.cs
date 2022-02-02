using LoanManagementSystem.Common.Cookie;

namespace LoanManagementSystem.App.Services.Cookie.Contracts
{
    public interface ICookieHelper
    {
        public Task<CookieModel> GetCookieValue(string cookieName);

        public Task AddCookie(string cookieName, string cookieValue, DateTime expires);

        public Task Clear(string cookieName);
    }
}
