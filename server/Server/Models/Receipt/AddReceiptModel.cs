using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models.Receipt
{
    public class AddReceiptModel
    {
        public int MachineId { get; set; }
        public ICollection<int> ContainersId{ get; set; }
    }
}
