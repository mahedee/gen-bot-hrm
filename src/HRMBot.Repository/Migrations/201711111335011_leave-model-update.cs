namespace HRMBot.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class leavemodelupdate : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.LeaveBalances");
            AddColumn("dbo.LeaveBalances", "TotalCasualLeave", c => c.Int(nullable: false));
            AddColumn("dbo.LeaveBalances", "TotalSickLeave", c => c.Int(nullable: false));
            AddColumn("dbo.LeaveBalances", "TotalAnnualLeave", c => c.Int(nullable: false));
            AddColumn("dbo.LeaveBalances", "AvailedCasualLeave", c => c.Int(nullable: false));
            AlterColumn("dbo.LeaveBalances", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.LeaveBalances", "Id");
            CreateIndex("dbo.LeaveBalances", "Id");
            AddForeignKey("dbo.LeaveBalances", "Id", "dbo.Employees", "Id");
            DropColumn("dbo.LeaveBalances", "EmployeeId");
            DropColumn("dbo.LeaveBalances", "CasualLeaveBalance");
            DropColumn("dbo.LeaveBalances", "SickLeaveBalance");
            DropColumn("dbo.LeaveBalances", "AnnualLeaveBalance");
            DropColumn("dbo.LeaveBalances", "AvailedLeave");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LeaveBalances", "AvailedLeave", c => c.Int(nullable: false));
            AddColumn("dbo.LeaveBalances", "AnnualLeaveBalance", c => c.Int(nullable: false));
            AddColumn("dbo.LeaveBalances", "SickLeaveBalance", c => c.Int(nullable: false));
            AddColumn("dbo.LeaveBalances", "CasualLeaveBalance", c => c.Int(nullable: false));
            AddColumn("dbo.LeaveBalances", "EmployeeId", c => c.Int(nullable: false));
            DropForeignKey("dbo.LeaveBalances", "Id", "dbo.Employees");
            DropIndex("dbo.LeaveBalances", new[] { "Id" });
            DropPrimaryKey("dbo.LeaveBalances");
            AlterColumn("dbo.LeaveBalances", "Id", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.LeaveBalances", "AvailedCasualLeave");
            DropColumn("dbo.LeaveBalances", "TotalAnnualLeave");
            DropColumn("dbo.LeaveBalances", "TotalSickLeave");
            DropColumn("dbo.LeaveBalances", "TotalCasualLeave");
            AddPrimaryKey("dbo.LeaveBalances", "Id");
        }
    }
}
