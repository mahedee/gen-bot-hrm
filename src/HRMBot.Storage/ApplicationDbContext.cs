using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMBot.Storage.Models;
using System.Data.Entity;

namespace HRMBot.Storage
{
    class ApplicationDbContext : DbContext
    {

        public DbSet<Employee> Employees { get; set; }
        public DbSet<MobileNumber> MobileNumbers { get; set; }
    }
}
