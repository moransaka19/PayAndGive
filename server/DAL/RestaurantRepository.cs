using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class RestaurantRepository : BaseRepository<Restaurant>
    {
        protected override IQueryable<Restaurant> BaseQuery => base.BaseQuery;
        public RestaurantRepository(ApplicationDbContext context) : base(context)
        {

        }

        public ICollection<Restaurant> GetAllRestaurantsWithChild()
        {
            return BaseQuery.Include(r => r.Machines).ThenInclude(m => m.Containers).ThenInclude(c => c.Eat).ToList();
        }
    }
}
