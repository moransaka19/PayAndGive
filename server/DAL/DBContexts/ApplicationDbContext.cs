using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.DataEncryption;
using Microsoft.EntityFrameworkCore.DataEncryption.Providers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class ApplicationDbContext : DbContext
    {
        private readonly byte[] _encryptionKey = AesProvider.GenerateKey(AesKeySize.AES128Bits).Key;
        private readonly byte[] _encryptionIV = AesProvider.GenerateKey(AesKeySize.AES128Bits).IV;
        private readonly IEncryptionProvider _provider;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            _provider = new AesProvider(_encryptionKey, _encryptionIV);
            //Database.EnsureCreated();
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
                    Login = "Admin",
                    Password = "ADGjgVNFqMy8qsaVNwuhPyW96mam0F6+zuAgkLjiNTc7YFfz4zoo4YWk7qnFTCciPg==",
                    Name = "Admin",
                    RoleId = 1
                }
            });
            modelBuilder.Entity<Machine>().HasData(new[]
            {
                new Machine
                {
                    Id = 1,
                    State = "test",
                    Value = 20,
                }
            });
            modelBuilder.Entity<MContainer>().HasData(new[]
            {
                new MContainer
                {
                    Id = 1,
                    MachineId = 1,
                    IsDeleted = false,
                    EatId = 2
                },
                new MContainer
                {
                    Id = 2,
                    MachineId = 1,
                    IsDeleted = false,
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

            modelBuilder.UseEncryption(_provider);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Eat> Eats { get; set; }
        public DbSet<Machine> Machines { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<MContainer> Containers { get; set; }
    }
}
