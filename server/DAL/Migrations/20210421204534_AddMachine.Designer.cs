﻿// <auto-generated />
using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210421204534_AddMachine")]
    partial class AddMachine
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Eat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int?>("ReceiptId")
                        .HasColumnType("int");

                    b.Property<int>("TimeExpiredMin")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ReceiptId");

                    b.ToTable("Eats");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            Name = "Eat2",
                            Price = 2,
                            TimeExpiredMin = 5
                        },
                        new
                        {
                            Id = 1,
                            Name = "Eat1",
                            Price = 10,
                            TimeExpiredMin = 10
                        });
                });

            modelBuilder.Entity("Domain.Machine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Machines");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            State = "test"
                        });
                });

            modelBuilder.Entity("Domain.MachineContainer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EatId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FixedLoadingTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsEmpty")
                        .HasColumnType("bit");

                    b.Property<int>("MachineId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EatId");

                    b.HasIndex("MachineId");

                    b.ToTable("MContainers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EatId = 2,
                            FixedLoadingTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsEmpty = false,
                            MachineId = 1
                        },
                        new
                        {
                            Id = 2,
                            EatId = 1,
                            FixedLoadingTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsEmpty = false,
                            MachineId = 1
                        });
                });

            modelBuilder.Entity("Domain.Receipt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MachineId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MachineId");

                    b.HasIndex("UserId");

                    b.ToTable("Receipts");
                });

            modelBuilder.Entity("Domain.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Customer"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Operator"
                        });
                });

            modelBuilder.Entity("Domain.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Money")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Login = "Test",
                            Money = 100m,
                            Name = "Test",
                            Password = "",
                            RoleId = 2
                        });
                });

            modelBuilder.Entity("Domain.Eat", b =>
                {
                    b.HasOne("Domain.Receipt", null)
                        .WithMany("EatList")
                        .HasForeignKey("ReceiptId");
                });

            modelBuilder.Entity("Domain.MachineContainer", b =>
                {
                    b.HasOne("Domain.Eat", "Eat")
                        .WithMany()
                        .HasForeignKey("EatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Machine", "Machine")
                        .WithMany("MachineContainers")
                        .HasForeignKey("MachineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Eat");

                    b.Navigation("Machine");
                });

            modelBuilder.Entity("Domain.Receipt", b =>
                {
                    b.HasOne("Domain.Machine", "Machine")
                        .WithMany()
                        .HasForeignKey("MachineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Machine");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.User", b =>
                {
                    b.HasOne("Domain.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Domain.Machine", b =>
                {
                    b.Navigation("MachineContainers");
                });

            modelBuilder.Entity("Domain.Receipt", b =>
                {
                    b.Navigation("EatList");
                });
#pragma warning restore 612, 618
        }
    }
}
