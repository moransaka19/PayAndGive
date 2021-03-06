using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class MContainer : BaseEntity
    {
        public DateTime FixedLoadingTime { get; set; }
        public bool IsDeleted { get; set; }
        public int EatId { get; set; }
        public Eat Eat { get; set; }
        public int MachineId { get; set; }
        public Machine Machine { get; set; }
        public bool ReadyForOpen { get; set; }
        public string CountryName { get; set; }
    }
}
