namespace HRMBot.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifymodels : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserInfoes", "Id", "dbo.Employees");
            DropForeignKey("dbo.LeaveBalances", "Id", "dbo.Employees");
            DropIndex("dbo.LeaveBalances", new[] { "Id" });
            DropIndex("dbo.UserInfoes", new[] { "Id" });
            DropPrimaryKey("dbo.LeaveBalances");
            DropPrimaryKey("dbo.UserInfoes");
            AddColumn("dbo.Employees", "Email", c => c.String());
            AddColumn("dbo.Employees", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.LeaveBalances", "EmployeeId", c => c.Int(nullable: false));
            AlterColumn("dbo.LeaveBalances", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.UserInfoes", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.LeaveBalances", "Id");
            AddPrimaryKey("dbo.UserInfoes", "Id");
            CreateIndex("dbo.Employees", "UserId");
            CreateIndex("dbo.LeaveBalances", "EmployeeId");
            AddForeignKey("dbo.Employees", "UserId", "dbo.UserInfoes", "Id");
            AddForeignKey("dbo.LeaveBalances", "EmployeeId", "dbo.Employees", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LeaveBalances", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Employees", "UserId", "dbo.UserInfoes");
            DropIndex("dbo.LeaveBalances", new[] { "EmployeeId" });
            DropIndex("dbo.Employees", new[] { "UserId" });
            DropPrimaryKey("dbo.UserInfoes");
            DropPrimaryKey("dbo.LeaveBalances");
            AlterColumn("dbo.UserInfoes", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.LeaveBalances", "Id", c => c.Int(nullable: false));
            DropColumn("dbo.LeaveBalances", "EmployeeId");
            DropColumn("dbo.Employees", "UserId");
            DropColumn("dbo.Employees", "Email");
            AddPrimaryKey("dbo.UserInfoes", "Id");
            AddPrimaryKey("dbo.LeaveBalances", "Id");
            CreateIndex("dbo.UserInfoes", "Id");
            CreateIndex("dbo.LeaveBalances", "Id");
            AddForeignKey("dbo.LeaveBalances", "Id", "dbo.Employees", "Id");
            AddForeignKey("dbo.UserInfoes", "Id", "dbo.Employees", "Id");
        }
    }
}
