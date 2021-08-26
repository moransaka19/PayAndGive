using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Interfaces
{
    public class ContainerRepository : BaseRepository<Container>
    {
        protected override IQueryable<Container> BaseQuery => base.BaseQuery.Include(c => c.Eat);
        public ContainerRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
