using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMBot.Repository.Models;

namespace HRMBot.Repository
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("Data Source=tcp:mahedee.database.windows.net,1433;Initial Catalog=hrmbotdb;User ID=mahedee;Password=Leads@123") // AttachDbFileName= |DataDirectory|\\myDbFile.mdf;
        {
            
        }

        public DbSet<User> Users { get; set; }
    }
}
