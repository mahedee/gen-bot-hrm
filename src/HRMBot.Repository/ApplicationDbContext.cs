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
        public ApplicationDbContext() : base("Server=(localdb)\\Test;Integrated Security=true;AttachDbFileName= myDbFile;")
        {
            
        }

        public DbSet<User> Users { get; set; }
    }
}
