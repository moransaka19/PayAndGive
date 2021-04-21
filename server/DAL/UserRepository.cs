using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
