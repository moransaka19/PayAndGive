using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class PreorderRepository : BaseRepository<Preorder>
    {
        protected override IQueryable<Preorder> BaseQuery => base.BaseQuery;
        public PreorderRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
