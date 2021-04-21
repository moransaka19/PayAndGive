using Common;
using DAL.Interfaces;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class RoleRepository : BaseRepository<Role>
    {
        public RoleRepository(ApplicationDbContext context) : base(context)
        {

        }

        public Role GetRole(RoleEnum role)
        {
            var roleInt = (int)role;
            return GetAll(u => u.Id == roleInt).FirstOrDefault();
        }
    }
}
