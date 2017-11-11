using System.Data.Entity;
using HRMBot.Models;
using HRMBot.Repository.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace HRMBot.Repository
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("Data Source=tcp:mahedee.database.windows.net,1433;Initial Catalog=hrmbotdb;User ID=mahedee;Password=Leads@123")
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<LeaveBalance> LeaveBalances { get; set; }
        public DbSet<UserInfo> UserInfos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Employee>().HasMany(i => i.UserInfo).WithRequired().WillCascadeOnDelete(false);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}
