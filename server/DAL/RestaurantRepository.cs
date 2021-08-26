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
    }
}
