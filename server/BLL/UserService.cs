using Common;
using DAL;
using DAL.Interfaces;
using Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Web.Helpers;

namespace BLL
{
    public class UserService
    {

        private readonly UserRepository _userRepository;
        private readonly RoleRepository _roleRepository;

        public UserService(UserRepository userRepository,
            RoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userRepository.GetAll();
        }
        public void DeleteUser(int id)
        {
            _userRepository.Delete(id);
        }
        public bool IsLoginTaken(string login)
        {
            return _userRepository.GetAll(u => u.Login == login).FirstOrDefault() != null;
        }
        public bool IsNameTaken(string name)
        {
            return _userRepository.GetAll(u => u.Name == name).FirstOrDefault() != null;
        }
        public User Register(string login, string name, string password, DateTime dob, RoleEnum roleEnum)
        {
            var hashPassword = HashPassword(password);
            var role = _roleRepository.GetRole(roleEnum);
            var user = new User()
            {
                Login = login,
                Name = name,
                Password = hashPassword,
                DOB = dob,
                Money = 0,
                Role = role
            };

            _userRepository.Add(user);

            return user;
        }
        public User Authenticate(User model)
        {
            var user = _userRepository.GetAll(x => x.Login == model.Login && !x.IsDeleted)
               .SingleOrDefault();

            if (user == null) return null;

            return Crypto.VerifyHashedPassword(user.Password, model.Password) ? user : null;
        }
        private string HashPassword(string rawPassword)
        {
            return Crypto.HashPassword(rawPassword);
        }
        public User GetCurrentUser(HttpContext http)
        {
            return _userRepository.GetById(int.Parse(http.User
                .Claims.First(c => c.Type == JwtRegisteredClaimNames.Sub)
                .Value));
        }
        public User GetById(int id)
        {
            return _userRepository.GetById(id);
        }
        public void AddMoney(User model, decimal money)
        {
            model.Money += money;
            _userRepository.Update(model);
        }
    }
}
