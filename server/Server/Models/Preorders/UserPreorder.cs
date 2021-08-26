using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models.Preorders
{
    public class UserPreorder
    {
        public string CreatedDateTime { get; set; }
        public Eat Eat { get; set; }
    }
}
