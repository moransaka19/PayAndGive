using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public class ReceiptRepository : BaseRepository<Receipt>
    {
        public ReceiptRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
