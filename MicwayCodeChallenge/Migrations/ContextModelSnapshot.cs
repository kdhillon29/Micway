﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MicwayCodeChallenge.DbContexts;

namespace MicwayCodeChallenge.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MicwayCodeChallenge.Entities.Driver", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<DateTime>("Dob")
                        .HasColumnType("date")
                        .HasColumnName("dob");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("firstName");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("lastName");

                    b.HasKey("Id");

                    b.ToTable("Drivers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                            Dob = new DateTime(1999, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "otto.grissom@micway.com",
                            FirstName = "Otto",
                            LastName = "Grissom"
                        },
                        new
                        {
                            Id = new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                            Dob = new DateTime(1986, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "fredrick.janson@micway.com",
                            FirstName = "Fredrick",
                            LastName = "Janson"
                        },
                        new
                        {
                            Id = new Guid("2902b665-1190-4c70-9915-b9c2d7680450"),
                            Dob = new DateTime(1992, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "ike.angel@micway.com",
                            FirstName = "Ike",
                            LastName = "Angel"
                        },
                        new
                        {
                            Id = new Guid("102b566b-ba1f-404c-b2df-e2cde39ade09"),
                            Dob = new DateTime(1986, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "wyatt.kreps@micway.com",
                            FirstName = "Wyatt",
                            LastName = "Kreps"
                        },
                        new
                        {
                            Id = new Guid("5b3621c0-7b12-4e80-9c8b-3398cba7ee05"),
                            Dob = new DateTime(1990, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "houston.chrysler@micway.com",
                            FirstName = "Houston",
                            LastName = "Chrysler"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
