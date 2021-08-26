using System;

namespace Server.Models.Containers
{
    public class AddContainerModel
    {
        public DateTime CreatedTime { get; set; }
        public bool IsBought { get; set; }
        public int EatId { get; set; }
        public int MachineId { get; set; }
    }
}
