using LoanManagementSystem.Common.Authentication;
using LoanManagementSystem.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Services.UserOperations.Contracts
{
    public interface IUserService
    {
        public Task AddUserAsync(UserAuthenticateModel userModel);

        public User GetUserByName(string name);

        public User GetUserByUserModel(UserAuthenticateModel userModel);

        public User GetUserForGenerateToken(UserAuthenticateModel userModel);

        public Task UpdateTokenExpiringDateForUserAsync(User user, DateTime expiringTime);
        
    }
}
