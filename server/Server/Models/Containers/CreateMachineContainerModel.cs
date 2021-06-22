using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models.Containers
{
    public class CreateMachineContainerModel
    {
        public DateTime FixedLoadingTime { get; set; }
        public bool IsEmpty { get; set; }
        public string CountryName { get; set; }
        public int EatId { get; set; }
        public int MachineId { get; set; }
    }
}
