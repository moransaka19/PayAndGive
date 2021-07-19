using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class User : BaseEntity
    {
        [Encrypted]
        public String Name { get; set; }
        [Encrypted]
        public string Login { get; set; }
        public string Password { get; set; }
        [Encrypted]
        public decimal Money { get; set; }
        public Role Role { get; set; }
        public int RoleId { get; set; }
    }
}
