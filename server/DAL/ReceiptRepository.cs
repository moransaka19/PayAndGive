using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public class ReceiptRepository : BaseRepository<Receipt>, IReceiptRepository
    {
        public ReceiptRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
