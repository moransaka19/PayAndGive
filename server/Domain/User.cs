using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class User : BaseEntity
    {
        //TODO: May dont work String ==> string
        [Encrypted]
        public string Name { get; set; }
        [Encrypted]
        public string Login { get; set; }
        public string Password { get; set; }
        [Encrypted]
        public decimal Money { get; set; }
        [Encrypted]
        public DateTime DOB { get; set; }
        public bool IsDeleted { get; set; }
        public Role Role { get; set; }
        public int RoleId { get; set; }
    }
}
