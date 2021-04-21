using DAL.Interfaces;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
