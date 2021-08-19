using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Interfaces
{
    public class ReceiptRepository : BaseRepository<Receipt>
    {
        protected override IQueryable<Receipt> BaseQuery => base.BaseQuery.Include(bq => bq.User)
            .Include(bq => bq.Container)
            .ThenInclude(bq => bq.Eat);
        public ReceiptRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
