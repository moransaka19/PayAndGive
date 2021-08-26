using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Machine : BaseEntity
    {
        public int Value { get; set; }
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}
