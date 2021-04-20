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
    public class TitleConfiguration : IEntityTypeConfiguration<Title>
    {
        public void Configure(EntityTypeBuilder<Title> builder)
        {
            builder.ToTable("Title").HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("TitleId");
            builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.HasData(new List<Title>()
            {
                new Title()
                {
                    Id = 1, Name = "JuniorDev"
                },
                new Title()
                {
                    Id = 2, Name = "MiddleDev"
                },
                new Title()
                {
                    Id = 3, Name = "SeniorDev"
                }
            });
        }
    }
}
