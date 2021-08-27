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
        protected override IQueryable<Receipt> BaseQuery => base.BaseQuery.Include(r => r.Container);
        public ReceiptRepository(ApplicationDbContext context) : base(context)
        {

        }

        public IEnumerable<Receipt> GetAllReceiptWithContainer()
        {
            BaseQuery.Include(r => r.Container);
            return BaseQuery.ToList();
        }
    }
}
