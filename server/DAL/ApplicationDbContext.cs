using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Eat> Eats { get; set; }
        public DbSet<Machine> Machines { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<MContainer> MContainers { get; set; }
    }
}
