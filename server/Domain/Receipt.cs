using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Receipt : BaseEntity
    {
        public DateTime DateTimeCreated { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int ContainerId { get; set; }
        public Container Container { get; set; }
    }
}
