using LoanManagementSystem.Common.Authentication;
using Microsoft.AspNetCore.Identity;
using LoanManagementSystem.Domain.Entity;
using LoanManagementSystem.Services.UserOperations.Contracts;

namespace LoanManagementSystem.Services.UserOperations
{
    public class UserService : IUserService
    {
        private UserManager<User> _userManager;        

        public UserService(
            UserManager<User> userManager)


        {
            _userManager = userManager;
          
        }

        public async Task AddUserAsync(UserAuthenticateModel userModel)
        {            
            
            User user = new User
            {
                Name = userModel.Name,
                UserName = userModel.Name,
                Email = $"test{userModel.Name}@localhost"
            };

            IdentityResult result = await _userManager.CreateAsync(user, userModel.Password);

            if (!result.Succeeded)
            {
                throw new Exception("Not valid user model");
            }
        }

        public User GetUserByName(string name)
        {
            User user = _userManager.Users.SingleOrDefault(x => x.Name == name);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            return user;
        }

        public User GetUserByUserModel(UserAuthenticateModel userModel)
        {
            if (string.IsNullOrEmpty(userModel.Name) || string.IsNullOrEmpty(userModel.Password))
            {
                throw new Exception("Invalid user name or password");
            }

            User user = GetUserByName(userModel.Name);

            return user;
        }

        public User GetUserForGenerateToken(UserAuthenticateModel userModel)
        {
            User user = GetUserByUserModel(userModel);
 

            return user;
        }

        public async Task UpdateTokenExpiringDateForUserAsync(User user, DateTime expiringTime)
        {
            user.TokenExpires = expiringTime;

            IdentityResult result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                throw new Exception("Unsuccessful try to update token expire time");
            }
        }
    }
}
