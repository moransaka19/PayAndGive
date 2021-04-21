using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public class MContainerRepository : BaseRepository<MContainer>, IMContainerRepository
    {
        public MContainerRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
