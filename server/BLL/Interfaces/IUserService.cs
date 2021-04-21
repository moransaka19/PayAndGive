using Common;
using Domain;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        bool IsLoginTaken(string login);
        bool IsNameTaken(string name);
        User Register(string login, string name, string password, RoleEnum roleEnum);
        User Authenticate(User model);
        User GetCurrentUser(JwtSecurityToken token);
        User GetById(int id);
    }
}
