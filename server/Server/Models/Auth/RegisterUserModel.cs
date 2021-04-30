using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models.Auth
{
    public class RegisterUserModel
    {
        public string Login { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public RoleEnum Role { get; set; }
    }
}
