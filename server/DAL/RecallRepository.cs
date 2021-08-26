using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class RecallRepository : BaseRepository<Recall>
    {
        protected override IQueryable<Recall> BaseQuery => base.BaseQuery;
        public RecallRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
