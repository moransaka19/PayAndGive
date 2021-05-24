using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Machine : BaseEntity
    {
        public string State { get; set; }
        public int Value { get; set; }
        public IEnumerable<MContainer> MachineContainers { get; set; }

        public Machine()
        {
            MachineContainers = new List<MContainer>();
        }
    }
}
