using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Interfaces
{
    public class EatRepository : BaseRepository<Eat>
    {
        protected override IQueryable<Eat> BaseQuery => base.BaseQuery;

        public EatRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
