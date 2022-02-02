using LoanManagementSystem.App.Services.Cookie.Contracts;
using LoanManagementSystem.Common.Cookie;
using Microsoft.JSInterop;

namespace LoanManagementSystem.App.Services.Cookie
{

    public class CookieHelper : ICookieHelper
    {
        private readonly IJSRuntime _jsRuntime;

        public CookieHelper(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task AddCookie(string cookieName, string cookieValue, DateTime expires)
        {
            await _jsRuntime.InvokeVoidAsync("eval", $"document.cookie = \"{cookieName}={cookieValue}; expires={expires.ToUniversalTime().ToString("R")};\"");
        }

        public async Task Clear(string cookieName)
        {
            await _jsRuntime.InvokeVoidAsync("eval", $"document.cookie = \"{cookieName}=; expires={DateTime.MinValue.ToUniversalTime().ToString("R")};\"");
        }

        private async Task<CookieModel> GetAllCookies()
        {
            CookieModel cookieValueModelToReturn;

            try
            {
                string cookiesStringRepresentation = await _jsRuntime.InvokeAsync<string>("eval", "document.cookie");

                cookieValueModelToReturn = new CookieModel
                {
                    Present = true,
                    Value = cookiesStringRepresentation
                };

                return cookieValueModelToReturn;

            }
            catch (Exception)
            {
                cookieValueModelToReturn = new CookieModel
                {
                    Present = false,
                    Value = string.Empty
                };

                return cookieValueModelToReturn;
            }
        }

        public async Task<CookieModel> GetCookieValue(string cookieName)
        {
            CookieModel allCookies = await GetAllCookies();

            CookieModel cookieValueModelToReturn;

            if (!allCookies.Present)
            {
                cookieValueModelToReturn = new CookieModel
                {
                    Present = false,
                    Value = string.Empty
                };

                return cookieValueModelToReturn;
            }

            string stringRepresentationOfCookies = allCookies.Value;

            (int tokenCookieStart, int tokenValueStart, int tokenValueEnd) = GetCookieValueDelimiters(stringRepresentationOfCookies, cookieName);

            if (tokenCookieStart == -1 || tokenValueStart == -1 || tokenValueEnd == -1)
            {

                cookieValueModelToReturn = new CookieModel
                {
                    Present = false,
                    Value = string.Empty
                };

                return cookieValueModelToReturn;
            }

            string cookieValue = stringRepresentationOfCookies.Substring(tokenValueStart, tokenValueEnd - tokenValueStart);

            cookieValueModelToReturn = new CookieModel
            {
                Present = true,
                Value = cookieValue
            };

            return cookieValueModelToReturn;
        }

        private Tuple<int, int, int> GetCookieValueDelimiters(string source, string nameOfCookie)
        {
            int tokenCookieIndex = source.IndexOf(nameOfCookie, StringComparison.Ordinal);

            int tokenCookieValueStartIndex = -1;

            int tokenCookieValueEndIndex = -1;

            if (tokenCookieIndex != -1)
            {
                string substringAfterToken = source.Substring(tokenCookieIndex);

                tokenCookieValueStartIndex = substringAfterToken.IndexOf("=", StringComparison.Ordinal);

                tokenCookieValueEndIndex = substringAfterToken.IndexOf(";", StringComparison.Ordinal);

                tokenCookieValueEndIndex = tokenCookieValueEndIndex == -1 ? substringAfterToken.Length : tokenCookieValueEndIndex;
            }

            return new Tuple<int, int, int>(tokenCookieIndex, tokenCookieIndex + tokenCookieValueStartIndex + 1, tokenCookieIndex + tokenCookieValueEndIndex);
        }
    }

}
