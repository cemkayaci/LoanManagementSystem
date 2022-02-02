using LoanManagementSystem.App;
using LoanManagementSystem.App.Services.Authentication;
using LoanManagementSystem.App.Services.Authentication.Contracts;
using LoanManagementSystem.App.Services.Cookie;
using LoanManagementSystem.App.Services.Cookie.Contracts;
using LoanManagementSystem.App.Services.Loan;
using LoanManagementSystem.App.Services.Loan.Contracts;
using LoanManagementSystem.App.Services.User;
using LoanManagementSystem.App.Services.User.Contracts;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services.AddSingleton<ICookieHelper, CookieHelper>();
builder.Services.AddSingleton<IAuthState, AuthState>();
builder.Services.AddHttpClient<IUserService, UserService>(client => client.BaseAddress = new Uri("https://localhost:7045/"));
builder.Services.AddHttpClient<ILoanService, LoanService>(client => client.BaseAddress = new Uri("https://localhost:7045/"));

await builder.Build().RunAsync();
