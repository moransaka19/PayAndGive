using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Receipt : BaseEntity
    {
        public int MachineId { get; set; }
        public Machine Machine { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<MContainer> Containers { get; set; }

        public Receipt()
        {
            Containers = new List<MContainer>();
        }
    }
}
