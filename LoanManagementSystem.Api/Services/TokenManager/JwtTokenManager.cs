using LoanManagementSystem.Api.Helper;
using LoanManagementSystem.Common.Token;
using LoanManagementSystem.Domain.Entity;
using LoanManagementSystem.Services.TokenManager.Contracts;

using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Services.TokenManager
{
    public class JwtTokenManager : IJwtTokenManager
    {
        public TokenModel GenerateJwtToken(User user, Role role)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(AuthenticationOptions.SECRET_TOKEN);

            DateTime expiringTime = DateTime.UtcNow.Add(TimeSpan.FromMinutes(AuthenticationOptions.TIME));

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("ID", user.Id),
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Role, role.ToString())
                }),
                Expires = expiringTime,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256),
                Audience = AuthenticationOptions.AUDIENCE,
                Issuer = AuthenticationOptions.ISSUER,
                NotBefore = DateTime.UtcNow,
            };

            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            string tokenStringRepresentation = tokenHandler.WriteToken(token);

            TokenModel tokenModelToReturn = new TokenModel
            {
                Token = tokenStringRepresentation,
                ExpireTime = expiringTime
            };

            return tokenModelToReturn;
        }

        public string GetUserNameAuthorizedByToken(string token)
        {
            if (token.StartsWith("Bearer "))
            {
                token = token.Replace("Bearer ", "");
            }

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            JwtSecurityToken result = handler.ReadJwtToken(token);

            string userName = result.Claims.SingleOrDefault(claim => claim.Type == "unique_name")?.Value;

            return userName;
        }
    }
}
