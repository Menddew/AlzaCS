﻿// <auto-generated />
using AlzaCS.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AlzaCS.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250328173941_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.3");

            modelBuilder.Entity("AlzaCS.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "A stylish T-shirt",
                            ImageUrl = "https://example.com/tshirt.jpg",
                            Name = "T-Shirt",
                            Price = 19.99m,
                            Quantity = 100
                        },
                        new
                        {
                            Id = 2,
                            Description = "A cool cap",
                            ImageUrl = "https://example.com/cap.jpg",
                            Name = "Cap",
                            Price = 9.99m,
                            Quantity = 50
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
