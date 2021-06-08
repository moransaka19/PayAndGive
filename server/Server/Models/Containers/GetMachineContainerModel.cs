using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models.Containers
{
    public class GetMachineContainerModel
    {
        public int Id { get; set; }
        public int MachineId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
