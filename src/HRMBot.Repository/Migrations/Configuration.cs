using HRMBot.Models;
using System.Data.Entity.Migrations;
using System.Linq;

namespace HRMBot.Repository.Migrations
{
    

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            var ratan = context.Employees.FirstOrDefault(p => p.MobileNo.Equals("01771998817"));
            if (ratan == null)
            {
                ratan = new Employee
                {
                    FullName = "Ratan Sunder Parai",
                    MobileNo = "01771998817",
                    Address = "Dhaka, Bangladesh",
                    Email = "ratanparai@gmail.com",
                    Designation = "Software Engineer"
                };

                context.Employees.Add(ratan);
                context.SaveChanges();
            }

            var ratanLeaves = context.LeaveBalances.FirstOrDefault(p => p.Id.Equals(ratan.Id));
            if (ratanLeaves == null)
            {
                ratanLeaves = new LeaveBalance
                {
                    EmployeeId = ratan.Id,
                    TotalAnnualLeave = 20,
                    TotalCasualLeave = 10,
                    TotalSickLeave = 14,
                    AvailedAnnualLeave = 10,
                    AvailedCasualLeave = 5,
                    AvailedSickLeave = 6
                };
                context.LeaveBalances.Add(ratanLeaves);
                context.SaveChanges();
            }

            var mahedee = context.Employees.FirstOrDefault(p => p.MobileNo.Equals("01787139383"));
            if (mahedee == null)
            {
                mahedee = new Employee
                {
                    FullName = "Md. Mahedee Hasan",
                    MobileNo = "01787139383",
                    Address = "Dhaka",
                    Designation = "Senior Software Architect"
                };
                context.Employees.Add(mahedee);
                context.SaveChanges();
            }

            var mahedeeLeaves = context.LeaveBalances.FirstOrDefault(p => p.Id == mahedee.Id);
            if (mahedeeLeaves == null)
            {
                mahedeeLeaves = new LeaveBalance
                {
                    EmployeeId = mahedee.Id,
                    TotalAnnualLeave = 30,
                    TotalCasualLeave = 20,
                    TotalSickLeave = 14,
                    AvailedAnnualLeave = 22,
                    AvailedCasualLeave = 8,
                    AvailedSickLeave = 12
                };
                context.LeaveBalances.Add(mahedeeLeaves);
                context.SaveChanges();
            }

        }
    }
}
