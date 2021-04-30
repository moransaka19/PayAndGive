using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models.Eats
{
    public class AddEatModel
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int TimeExpiredMin { get; set; }
    }
}
