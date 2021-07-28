using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MicwayCodeChallenge.Entities;

namespace MicwayCodeChallenge.EntityConfigurations
{
    public class DriverConfiguration : IEntityTypeConfiguration<Driver>
    {
        public void Configure(EntityTypeBuilder<Driver> driver)
        {
            driver.HasKey(d => d.Id);
            
            driver.Property(d => d.Id)
                .HasColumnName("id");

            driver.Property(d => d.FirstName)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar")
                .HasColumnName("firstName");

            driver.Property(d => d.LastName)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar")
                .HasColumnName("lastName");
            
            driver.Property(d => d.Dob)
                .IsRequired()
                .HasColumnType("date")
                .HasColumnName("dob");

            driver.Property(d => d.Email)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("varchar")
                .HasColumnName("email");

            #region Data Seed

            driver.HasData(
                new Driver()
                {
                    Id = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                    FirstName = "Otto",
                    LastName = "Grissom",
                    Dob = new DateTime(1999, 7, 23),
                    Email = "otto.grissom@micway.com"
                },
                new Driver()
                {
                    Id = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                    FirstName = "Fredrick",
                    LastName = "Janson",
                    Dob = new DateTime(1986, 5, 21),
                    Email = "fredrick.janson@micway.com"
                },
                new Driver()
                {
                    Id = Guid.Parse("2902b665-1190-4c70-9915-b9c2d7680450"),
                    FirstName = "Ike",
                    LastName = "Angel",
                    Dob = new DateTime(1992, 12, 16),
                    Email = "ike.angel@micway.com"
                },
                new Driver()
                {
                    Id = Guid.Parse("102b566b-ba1f-404c-b2df-e2cde39ade09"),
                    FirstName = "Wyatt",
                    LastName = "Kreps",
                    Dob = new DateTime(1986, 3, 6),
                    Email = "wyatt.kreps@micway.com"
                },
                new Driver()
                {
                    Id = Guid.Parse("5b3621c0-7b12-4e80-9c8b-3398cba7ee05"),
                    FirstName = "Houston",
                    LastName = "Chrysler",
                    Dob = new DateTime(1990, 11, 23),
                    Email = "houston.chrysler@micway.com"
                }
            );

            #endregion
        }
    }
}