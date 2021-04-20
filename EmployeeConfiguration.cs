using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using EntityCodeFirst.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityCodeFirst.EntityConfiguration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employee").HasKey(p => p.Id);
            builder.Property(p => p.FirstName).HasColumnName("FirstName").HasMaxLength(50);
            builder.Property(p => p.LastName).IsRequired().HasColumnName("LastName").HasMaxLength(50);
            builder.Property(p => p.HiredDate).IsRequired().HasColumnName("HiredDate").HasColumnType("date");

            // builder.HasOne(d => d.Project)
            //    .WithMany(p => p.Employee)
            //    .HasForeignKey(d => d.ProjectId)
            //    .OnDelete(DeleteBehavior.Cascade);
            // builder.HasOne(d => d.Title)
            //    .WithMany(p => p.Employee)
            //    .HasForeignKey(d => d.TitleId)
            //    .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(d => d.Office)
               .WithMany(p => p.Employee)
               .HasForeignKey(d => d.OfficeId)
               .OnDelete(DeleteBehavior.Cascade);
            builder.HasData(new List<Employee>()
             {
                new Employee()
                {
                    Id = 9, FirstName = "John",

                    LastName = "Doe", DateOfBirth = new DateTime(2000, 12, 04),
                    HiredDate = new DateTime(2019, 08, 01),

                    // OfficeId = new Office().Id, TitleId = new Title().Id
                },

                new Employee()
                 {
                    Id = 2, FirstName = "Alice",
                    LastName = "Cooper", DateOfBirth = new DateTime(2002, 02, 04),
                    HiredDate = new DateTime(2018, 02, 03),

                    // OfficeId = new Office().Id,  TitleId = new Title().Id
                 }
             });
        }
    }
}
