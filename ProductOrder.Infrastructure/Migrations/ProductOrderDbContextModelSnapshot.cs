﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProductOrder.Infrastructure.Data;

#nullable disable

namespace ProductOrder.Infrastructure.Migrations
{
    [DbContext(typeof(ProductOrderDbContext))]
    partial class ProductOrderDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ProductOrder.Core.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("dc18e5ee-ef75-4cd7-89cd-ed4321eb4eb9"),
                            Description = "test1Desc",
                            Name = "test1",
                            Price = 22m
                        },
                        new
                        {
                            Id = new Guid("39c857ff-bba1-4fd4-99a7-0e3af426d680"),
                            Description = "test2Desc",
                            Name = "test2",
                            Price = 25m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
