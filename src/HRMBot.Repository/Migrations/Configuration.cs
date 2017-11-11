using HRMBot.Models;

namespace HRMBot.Repository.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HRMBot.Repository.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "HRMBot.Repository.ApplicationDbContext";
        }

        protected override void Seed(HRMBot.Repository.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            Employee[] employees =
            {
                new Employee
                {
                    FullName = "Ratan Sunder Parai",
                    Designation = "Software Engineer",
                    MobileNo = "01771998817",
                    Address = "Dhaka, Bangladesh"
                },
                new Employee
                {
                    FullName = "Md. Mahedee Hasan",
                    Designation = "Senior Software Architect",
                    MobileNo = "01787139383",
                    Address = "Dhaka, Bangladesh"
                }
            };

            context.Employees.AddOrUpdate(employees);
        }
    }
}
