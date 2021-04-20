using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EntityCodeFirst.Entities;

namespace EntityCodeFirst.EntityConfiguration
{
    public class OfficeConfiguration : IEntityTypeConfiguration<Office>
    {
        public void Configure(EntityTypeBuilder<Office> builder)
        {
            builder.ToTable("Office").HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("Id");
            builder.Property(p => p.Title).IsRequired().HasColumnName("Title").HasMaxLength(100);
            builder.Property(p => p.Location).IsRequired().HasColumnName("Location").HasMaxLength(100);
            builder.HasData(new List<Office>()
            {
                new Office()
                {
                    Id = 1, Location = "Sydney", Title = "WestOffice"
                },
                new Office()
                {
                    Id = 2, Location = "Canberra", Title = "ShoreOffice"
                }
            });
        }
    }
}
