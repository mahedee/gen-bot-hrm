using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMBot.Repository.Models;

namespace HRMBot.Repository
{
    class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}
