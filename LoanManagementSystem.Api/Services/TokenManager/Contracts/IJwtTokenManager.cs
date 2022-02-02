using LoanManagementSystem.Common.Token;
using LoanManagementSystem.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Services.TokenManager.Contracts
{
    public interface IJwtTokenManager
    {
        public TokenModel GenerateJwtToken(User user, Role role);

        public string GetUserNameAuthorizedByToken(string token);
    }
}
