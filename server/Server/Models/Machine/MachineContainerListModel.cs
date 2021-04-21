using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models.Machine
{
    public class MachineContainerListModel
    {
        public IEnumerable<int> machineContainerIds { get; set; }
        public int UserId { get; set; }
        public int MachineId { get; set; }
    }
}
