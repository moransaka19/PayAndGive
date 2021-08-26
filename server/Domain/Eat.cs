using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Eat : BaseEntity
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int TimeExpired { get; set; }
    }
}
