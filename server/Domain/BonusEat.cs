using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class BonusEat: BaseEntity
    {
        public DateTime CreatedDateTime { get; set; }
        public Eat Eat { get; set; }
        public int EatId { get; set; }
        public Restaurant Restaurant { get; set; }
        public int RestaurantId { get; set; }

    }
}
