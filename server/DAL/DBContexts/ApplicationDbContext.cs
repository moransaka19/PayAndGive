﻿using Domain;
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
            modelBuilder.Entity<Role>().HasData(new[]
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
            modelBuilder.Entity<Machine>().HasData(new[]
            {
                new Machine
                {
                    Id = 1,
                    State = "test"
                }
            });
            modelBuilder.Entity<MachineContainer>().HasData(new[]
            {
                new MachineContainer
                {
                    Id = 1,
                    MachineId = 1,
                    IsEmpty = false,
                    EatId = 2
                },
                new MachineContainer
                {
                    Id = 2,
                    MachineId = 1,
                    IsEmpty = false,
                    EatId = 1
                }
            });

            modelBuilder.Entity<Eat>().HasData(new[]{

                new Eat
                {
                    Id = 2,
                    Name ="Eat2",
                    Price = 2,
                    TimeExpiredMin = 5
                },
                new Eat 
                {
                    Id = 1,
                    Name = "Eat1",
                    Price = 10,
                    TimeExpiredMin = 10
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
