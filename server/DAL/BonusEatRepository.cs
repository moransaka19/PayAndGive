using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class BonusEatRepository : BaseRepository<BonusEat>
    {
        protected override IQueryable<BonusEat> BaseQuery => base.BaseQuery;
        public BonusEatRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
