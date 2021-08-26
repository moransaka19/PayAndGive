using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models.BonusEats
{
    public class AddBonusEatModel
    {
        public int RestaurantId { get; set; }
        public IEnumerable<int> EatIds { get; set; }
    }
}
