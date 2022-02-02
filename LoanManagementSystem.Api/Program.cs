using LoanManagementSystem.Api.Helper;
using LoanManagementSystem.Calculations.Loan;
using LoanManagementSystem.Common.Config;
using LoanManagementSystem.Domain.Context;
using LoanManagementSystem.Domain.DbConnectionFactory.Cosmos;
using LoanManagementSystem.Domain.DbConnectionFactory.Cosmos.Contracts;
using LoanManagementSystem.Domain.Entity;
using LoanManagementSystem.Domain.Repositories.Loan;
using LoanManagementSystem.Domain.Repositories.Loan.Contracts;
using LoanManagementSystem.Services.Loan;
using LoanManagementSystem.Services.Loan.Contracts;
using LoanManagementSystem.Services.LoanDetails;
using LoanManagementSystem.Services.LoanDetails.Contracts;
using LoanManagementSystem.Services.TokenManager;
using LoanManagementSystem.Services.TokenManager.Contracts;
using LoanManagementSystem.Services.UserOperations;
using LoanManagementSystem.Services.UserOperations.Contracts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<LoansDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnectionString"),b =>b.MigrationsAssembly("LoanManagementSystem.Domain")));




builder.Services.AddIdentityCore<User>(option => {
    option.SignIn.RequireConfirmedAccount = false;
}).AddEntityFrameworkStores<LoansDbContext>()
.AddDefaultTokenProviders();

builder.Services.AddLogging();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    SymmetricSecurityKey token = AuthenticationOptions.GetSymmetricSecurityKey();

    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = token,

        ValidateIssuer = true,
        ValidIssuer = AuthenticationOptions.ISSUER,

        ValidateAudience = true,
        ValidAudience = AuthenticationOptions.AUDIENCE,

        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };
    options.SaveToken = true;
});


builder.Services.Configure<IdentityOptions>(options =>
{
    options.SignIn.RequireConfirmedEmail = false;
    options.SignIn.RequireConfirmedPhoneNumber = false;
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 4;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.Lockout.AllowedForNewUsers = false;

    options.User.AllowedUserNameCharacters =
        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";

    options.User.RequireUniqueEmail = true;
    options.Password.RequiredUniqueChars = 1;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
});

builder.Services.AddAuthorization(o => o.AddPolicy(
    "RequireAuthenticatedUserPolicy",
    builder => builder.RequireAuthenticatedUser()));

builder.Services.AddControllers();

builder.Services.AddScoped<EnabledCalculations>();
builder.Services.AddScoped<ILoanDetailsService, LoanDetailsService>();
builder.Services.AddScoped<ILoanService, LoanService>();

builder.Services.AddScoped<ICosmosDbClientFactory, CosmosDbClientFactory>();
builder.Services.AddScoped<ILoanRepositoriesFactory, LoanRepositoriesFactory>();
builder.Services.AddScoped<IJwtTokenManager, JwtTokenManager>();
builder.Services.AddScoped<IUserService, UserService>();

ApplicationConfig.SetAppSettingsProperties(builder.Configuration);

var app = builder.Build();

app.UseCors(builder =>
                builder.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyOrigin()
                .AllowAnyMethod()
                );

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
