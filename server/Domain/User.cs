using System;

namespace Domain
{
    public class User : BaseEntity
    {
        public String Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public decimal Money { get; set; }
        public Role Role { get; set; }
    }
}
