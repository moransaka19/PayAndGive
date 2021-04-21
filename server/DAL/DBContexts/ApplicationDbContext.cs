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
            modelBuilder.Entity<Role>().HasData(new []
            {
                new Role
                {
                    Id = 1,
                    Name = "Admin"
                },

                new Role
                {
                    Id = 2,
                    Name = "Customer"
                },

                new Role
                {
                    Id = 3,
                    Name = "Operator"
                },
            });
            modelBuilder.Entity<User>().HasData(new[]
            {
                new User
                {
                    Id = 1,
                    Login = "Test",
                    Password = "",
                    Name = "Test",
                    Money = 100,
                    RoleId = 2
                }
            });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Eat> Eats { get; set; }
        public DbSet<Machine> Machines { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<MachineContainer> MContainers { get; set; }
    }
}
