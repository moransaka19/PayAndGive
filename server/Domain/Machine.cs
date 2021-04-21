using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Machine : BaseEntity
    {
        public string State { get; set; }
        public IEnumerable<MachineContainer> MachineContainers { get; set; }

        public Machine()
        {
            MachineContainers = new List<MachineContainer>();
        }
    }
}
