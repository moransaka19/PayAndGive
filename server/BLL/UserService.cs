using BLL.Interfaces;
using Common;
using DAL.Interfaces;
using Domain;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Web.Helpers;

namespace BLL
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;

        public UserService(IUserRepository userRepository,
            IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        public bool IsLoginTaken(string login)
        {
            return _userRepository.GetAll(u => u.Login == login).FirstOrDefault() != null;
        }

        public bool IsNameTaken(string name)
        {
            return _userRepository.GetAll(u => u.Name == name).FirstOrDefault() != null;
        }

        public User Register(string login, string name, string password, RoleEnum roleEnum)
        {
            var hashPassword = HashPassword(password);
            var role = _roleRepository.GetRole(roleEnum);
            var user = new User()
            {
                Login = login,
                Name = name,
                Password = hashPassword,
                Role = role
            };

            _userRepository.Add(user);

            return user;
        }

        public User Authenticate(User model)
        {
            var user = _userRepository.GetAll(x => x.Login == model.Login)
               .SingleOrDefault();

            if (user == null) return null;

            return Crypto.VerifyHashedPassword(user.Password, model.Password) ? user : null;
        }

        private string HashPassword(string rawPassword)
        {
            return Crypto.HashPassword(rawPassword);
        }
        public User GetCurrentUser(JwtSecurityToken token)
        {
            return _userRepository.GetById(Convert.ToInt32(token.Claims.First(claim => claim.Type == "sub").Value));
        }
        public User GetById(int id)
        {
            return _userRepository.GetById(id);
        }
    }
}
