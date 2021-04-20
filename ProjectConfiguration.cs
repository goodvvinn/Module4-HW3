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
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("Project").HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("ProjectId");
            builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Budget).IsRequired().HasColumnType("money").HasColumnName("Budget");
            builder.Property(p => p.StartedDate).IsRequired().HasColumnType("date");
            builder.HasData(new List<Project>()
            {
                new Project()
                {
                    Name = "Laundry", Id = 5, Budget = 4000,
                    StartedDate = new DateTime(2019, 02, 04), Employee = new List<Employee>()
                }
            });
        }
    }
}
