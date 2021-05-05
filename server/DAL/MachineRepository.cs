using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Interfaces
{
    public class MachineRepository : BaseRepository<Machine>
    {
        protected override IQueryable<Machine> BaseQuery => base.BaseQuery
            .Include(m => m.MachineContainers)
            .ThenInclude(x => x.Eat);
        public MachineRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
