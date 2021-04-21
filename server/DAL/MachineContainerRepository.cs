using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public class MachineContainerRepository : BaseRepository<MachineContainer>, IMContainerRepository
    {
        public MachineContainerRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
