using System.Linq;
using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EntityCodeFirst.Entities;
using Microsoft.Extensions.Configuration;

namespace EntityCodeFirst
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            var connectionString = config.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            var options = optionsBuilder
                .UseSqlServer(connectionString)
                .Options;

            using (var db = new ApplicationContext(options))
            {
                var employees = db.Employee.ToList();
                foreach (var emp in employees)
                {
                    Console.WriteLine($"{emp.Id}.{emp.FirstName}." +
                        $"{emp.LastName} - {emp.HiredDate:dd/MM/yyyy}");
                }

                db.Employee.Add(new Employee()
                {
                    // Id = 4,
                    FirstName = "Bill",
                    LastName = "Murrey",
                    DateOfBirth = new DateTime(1991, 03, 30),
                    HiredDate = new DateTime(2016, 05, 05),

                    // OfficeId = new Office().Id,
                    // TitleId = new Title().Id
                });
                db.SaveChanges();
            }

            Console.Read();
        }
    }
}
