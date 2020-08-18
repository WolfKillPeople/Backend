using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WolfPeopleKill.POCO;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using WolfPeopleKill.Models;
using WolfPeopleKill.Interfaces;

namespace WolfPeopleKill.Services
{
    public class TokenAuthenticationService : IAuthenticateService
    {
        private readonly IUserService _userService;
        private readonly TokenManagement _tokenManagement;

        public TokenAuthenticationService(IUserService userService, IOptions<TokenManagement> tokenManagement)
        {
            _userService = userService;
            _tokenManagement = tokenManagement.Value;
        }

        public bool IAuthenticated(LoginDTO request, out string token)
        {
            token = string.Empty;
            if (!_userService.IsValid(request)) return false;
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, request.userName)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenManagement.Secret));
            var credentails = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var jwtToken = new JwtSecurityToken(_tokenManagement.Issuer, _tokenManagement.Audience, claims, expires: DateTime.Now.AddMinutes(_tokenManagement.AccessExpiration), signingCredentials: credentails);

            token = new JwtSecurityTokenHandler().WriteToken(jwtToken);

            return true;
        }
    }
}
