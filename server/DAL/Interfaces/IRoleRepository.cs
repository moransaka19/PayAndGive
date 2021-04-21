using Common;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IRoleRepository : IBaseRepository<Role>
    {
        Role GetRole(RoleEnum role);
    }
}
