using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Interfaces
{
    public class UserRepository : BaseRepository<User>
    {
        protected override IQueryable<User> baseQuery => base.baseQuery.Include(bq => bq.Role);
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }

    }
}
