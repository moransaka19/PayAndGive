using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class MachineContainer : BaseEntity
    {
        public DateTime FixedLoadingTime { get; set; }
        public bool IsEmpty { get; set; }
        public int EatId { get; set; }
        public Eat Eat { get; set; }
        public int MachineId { get; set; }
        public Machine Machine { get; set; }
    }
}
