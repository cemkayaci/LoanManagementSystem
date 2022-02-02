using LoanManagementSystem.Common.Authentication;
using LoanManagementSystem.Common.RouteConfig;
using LoanManagementSystem.Common.Token;
using LoanManagementSystem.Domain.Entity;
using LoanManagementSystem.Services.TokenManager.Contracts;
using LoanManagementSystem.Services.UserOperations.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace LoanManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IJwtTokenManager _jwtTokenManager;
        private readonly ILogger<UserController> _logger; 
        private readonly IUserService _userService;

        public UserController(
            ILogger<UserController> logger,
            IJwtTokenManager jwtTokenManager,
          
            IUserService userService
            )
        {
            _logger = logger;
            _jwtTokenManager = jwtTokenManager;
      
            _userService = userService;
        }

        [HttpPost(UserEndpoints.ADD_USER)]
        public async Task<IActionResult> Add([FromBody] UserAuthenticateModel userModel)
        {
            try
            {
                await _userService.AddUserAsync(userModel);

                return new OkResult();
            }
            catch (Exception exc)
            {
                const string message = "Error while adding user";

                _logger.LogError($"{message} {exc.Message}");

                return new BadRequestObjectResult(message);
            }
        }

        [HttpPost(UserEndpoints.AUTHORIZE_USER)]
        public async Task<IActionResult> Authenticate([FromBody] UserAuthenticateModel userModel)
        {
            try
            {
                
                User user = _userService.GetUserForGenerateToken(userModel);

                TokenModel accessToken = _jwtTokenManager.GenerateJwtToken(user, user.Role);

                await _userService.UpdateTokenExpiringDateForUserAsync(user, accessToken.ExpireTime);

                return new OkObjectResult(accessToken);
            }
            catch (Exception exc)
            {
                const string message = "Error while log in";

                _logger.LogError($"{message} {exc.Message}");

                return new BadRequestObjectResult(message);
            }
        }

        [HttpPost(UserEndpoints.UNAUTHORIZE_USER)]
        [Authorize]
        public async Task<IActionResult> LogOut([FromHeader] string authorization)
        {
            try
            {
                string userName = _jwtTokenManager.GetUserNameAuthorizedByToken(authorization);

                User user = _userService.GetUserByName(userName);

                await _userService.UpdateTokenExpiringDateForUserAsync(user, default);

                return new OkResult();
            }
            catch (Exception exc)
            {
                const string message = "Error while log out";

                _logger.LogError($"{message} {exc.Message}");

                return new BadRequestObjectResult(message);
            }
        }

    }
}
