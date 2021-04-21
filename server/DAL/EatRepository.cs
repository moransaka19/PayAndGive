using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public class EatRepository : BaseRepository<Eat>, IEatRepository
    {
        public EatRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
