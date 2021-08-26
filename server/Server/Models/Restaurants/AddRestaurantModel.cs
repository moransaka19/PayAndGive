using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models.Restaurants
{
    public class AddRestaurantModel
    {
        public string Name { get; set; }
        public double Lat { get; set; }
        public double Lang { get; set; }
        public string Country { get; set; }
    }
}
