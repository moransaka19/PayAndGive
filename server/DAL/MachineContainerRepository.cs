using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Interfaces
{
    public class MachineContainerRepository : BaseRepository<MachineContainer>
    {
        protected override IQueryable<MachineContainer> BaseQuery => base.BaseQuery
            .Include(b => b.Eat);
        public MachineContainerRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
