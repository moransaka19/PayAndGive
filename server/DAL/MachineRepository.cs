using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public class MachineRepository : BaseRepository<Machine>, IMachineRepository
    {
        public MachineRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
