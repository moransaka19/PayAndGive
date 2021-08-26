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
        protected override IQueryable<User> BaseQuery => base.BaseQuery.Include(bq => bq.Role);
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public void Delete(int id)
        {
            var user = GetById(id);
            user.IsDeleted = true;
            Update(user);
        }

    }
}
