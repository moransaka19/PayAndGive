using AuthOption;
using DAL;
using DAL.Interfaces;
using Domain;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace BLL
{
    public class TokenService
    {

        private readonly IOptions<AuthOptions> _authOpions;
        private readonly RoleRepository _roleRepository;

        public TokenService(IOptions<AuthOptions> authOpions,
            RoleRepository roleRepository)
        {
            _authOpions = authOpions;
            _roleRepository = roleRepository;
        }


        public string GenerateJwtToken(User user)
        {
            var authParams = _authOpions.Value;
            var securityKey = authParams.GetSymmetricSecurityKey();
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString())
            };

            var roles = _roleRepository.GetAll();

            claims.AddRange(roles
                .Where(role => user.Role.Id == role.Id)
                .Select(role => new Claim("role", role.Name)));

            var token = new JwtSecurityToken(authParams.Issuer,
                authParams.Audience,
                claims,
                expires: DateTime.Now.AddSeconds(authParams.TokenLifeTime),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public JwtSecurityToken GetCurrentToken(string accessToken)
        {
            var token = accessToken.Split(" ")[1];

            return new JwtSecurityTokenHandler().ReadToken(token) as JwtSecurityToken;
        }
    }
}
