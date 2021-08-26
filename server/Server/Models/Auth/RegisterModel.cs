using Common;
using System;

namespace Server.Models
{
    public class RegisterModel
    {
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime DOB { get; set; }
        public RoleEnum Role{ get; set; }
    }
}
