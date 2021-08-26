using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models.Recalls
{
    public class AddRecallModel
    {
        public string Description { get; set; }
        public int Rating { get; set; }
        public int UserId { get; set; }
        public int RestaurantId { get; set; }
    }
}
