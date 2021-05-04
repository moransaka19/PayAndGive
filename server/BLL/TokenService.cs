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

        private readonly AuthOptions _authOpions;
        private readonly RoleRepository _roleRepository;

        public TokenService(AuthOptions authOpions,
            RoleRepository roleRepository)
        {
            _authOpions = authOpions;
            _roleRepository = roleRepository;
        }


        public string GenerateJwtToken(User user)
        {
            var securityKey = _authOpions.GetSymmetricSecurityKey();
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString())
            };

            var roles = _roleRepository.GetAll();

            claims.AddRange(roles
                .Where(role => user.Role.Id == role.Id).ToList()
                .Select(role => new Claim("role", role.Name)));

            var token = new JwtSecurityToken(_authOpions.Issuer,
                _authOpions.Audience,
                claims,
                expires: DateTime.Now.AddSeconds(_authOpions.TokenLifeTime),
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
