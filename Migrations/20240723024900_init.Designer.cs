﻿// <auto-generated />
using BBC.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BBC.Api.Migrations
{
    [DbContext(typeof(BBCContext))]
    [Migration("20240723024900_init")]
    partial class init
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

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("GameEntityOrderEntity", b =>
                {
                    b.Property<int>("GamesId")
                        .HasColumnType("int");

                    b.Property<int>("OrdersId")
                        .HasColumnType("int");

                    b.HasKey("GamesId", "OrdersId");

                    b.HasIndex("OrdersId");

                    b.ToTable("GameEntityOrderEntity");
                });

            modelBuilder.Entity("BBC.Api.Entities.OrderEntity", b =>
                {
                    b.HasOne("BBC.Api.Entities.CustomerEntity", "CustomerDetails")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CustomerDetails");
                });

            modelBuilder.Entity("GameEntityOrderEntity", b =>
                {
                    b.HasOne("BBC.Api.Entities.GameEntity", null)
                        .WithMany()
                        .HasForeignKey("GamesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BBC.Api.Entities.OrderEntity", null)
                        .WithMany()
                        .HasForeignKey("OrdersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BBC.Api.Entities.CustomerEntity", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}