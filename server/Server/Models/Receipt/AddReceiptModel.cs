using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models.Receipt
{
    public class AddReceiptModel
    {
        public ICollection<int> ContainersId{ get; set; }
    }
}
