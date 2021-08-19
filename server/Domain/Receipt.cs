using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Receipt : BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int ContainerId { get; set; }
        public MContainer Container { get; set; }
    }
}
