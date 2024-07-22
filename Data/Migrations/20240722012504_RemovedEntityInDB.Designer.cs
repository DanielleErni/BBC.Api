﻿// <auto-generated />
using System;
using BBC.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BBC.Api.Data.Migrations
{
    [DbContext(typeof(BBCContext))]
    [Migration("20240722012504_RemovedEntityInDB")]
    partial class RemovedEntityInDB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BBC.Api.Entities.CustomerEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ContanctNumber")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ContanctNumber = 901,
                            Name = "Kyla"
                        },
                        new
                        {
                            Id = 2,
                            ContanctNumber = 902,
                            Name = "Sean"
                        },
                        new
                        {
                            Id = 3,
                            ContanctNumber = 903,
                            Name = "Jojo"
                        },
                        new
                        {
                            Id = 4,
                            ContanctNumber = 904,
                            Name = "Niks"
                        },
                        new
                        {
                            Id = 5,
                            ContanctNumber = 905,
                            Name = "Mat"
                        });
                });

            modelBuilder.Entity("BBC.Api.Entities.GameEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Games");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Genre = "Action",
                            Price = 59.990000000000002,
                            Quantity = 1,
                            Title = "Red Dead Redemption 2"
                        },
                        new
                        {
                            Id = 2,
                            Genre = "Fps",
                            Price = 69.689999999999998,
                            Quantity = 4,
                            Title = "Stalker"
                        },
                        new
                        {
                            Id = 3,
                            Genre = "Survival Horror",
                            Price = 120.25,
                            Quantity = 2,
                            Title = "Fear and Hunger"
                        },
                        new
                        {
                            Id = 4,
                            Genre = "Rpg",
                            Price = 75.049999999999997,
                            Quantity = 5,
                            Title = "Black Souls"
                        },
                        new
                        {
                            Id = 5,
                            Genre = "Rts",
                            Price = 59.990000000000002,
                            Quantity = 3,
                            Title = "StarCraft"
                        });
                });

            modelBuilder.Entity("BBC.Api.Entities.OrderEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CustomerDetailsId")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int?>("GameDetailsId")
                        .HasColumnType("int");

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CustomerDetailsId");

                    b.HasIndex("GameDetailsId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("BBC.Api.Entities.OrderEntity", b =>
                {
                    b.HasOne("BBC.Api.Entities.CustomerEntity", "CustomerDetails")
                        .WithMany()
                        .HasForeignKey("CustomerDetailsId");

                    b.HasOne("BBC.Api.Entities.GameEntity", "GameDetails")
                        .WithMany()
                        .HasForeignKey("GameDetailsId");

                    b.Navigation("CustomerDetails");

                    b.Navigation("GameDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
