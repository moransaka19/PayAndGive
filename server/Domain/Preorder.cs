using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Preorder : BaseEntity
    {
        public DateTime DateTimePreorder { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int EatId { get; set; }
        public Eat Eat { get; set; }
    }
}
