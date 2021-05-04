namespace Server.Models.Machine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class MachineModel
    {
        public int Id { get; set; }
        public string State { get; set; }
        public int Value { get; set; }
        public int Containers { get; set; }
    }
}
