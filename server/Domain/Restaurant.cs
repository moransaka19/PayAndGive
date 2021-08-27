using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Restaurant : BaseEntity
    {
        public string Name { get; set; }
        public double Lat { get; set; }
        public double Lang { get; set; }
        public string Country { get; set; }
        public IEnumerable<Machine> Machines { get; set; }
    }
}
