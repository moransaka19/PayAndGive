using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Container : BaseEntity
    {
        public DateTime CreatedTime { get; set; }
        public bool IsBought { get; set; }
        public int EatId { get; set; }
        public Eat Eat { get; set; }
        public int MachineId { get; set; }
        public Machine Machine { get; set; }
    }
}
