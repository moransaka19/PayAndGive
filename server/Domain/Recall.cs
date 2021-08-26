using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Recall : BaseEntity
    {
        public string Description { get; set; }
        public int Rating { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}
