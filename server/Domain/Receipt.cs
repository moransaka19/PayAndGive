using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Receipt : BaseEntity
    {
        public Machine Machine { get; set; }
        public User User { get; set; }
        public IEnumerable<Eat> EatList { get; set; }

        public Receipt()
        {
            EatList = new List<Eat>();
        }
    }
}
