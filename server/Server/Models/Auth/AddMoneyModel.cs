using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models.Auth
{
    public class AddMoneyModel
    {
        public int UserId { get; set; }
        public decimal Money { get; set; }  
    }
}
