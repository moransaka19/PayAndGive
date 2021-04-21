using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public class MachineRepository : BaseRepository<Machine>
    {
        public MachineRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
