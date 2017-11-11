namespace HRMBot.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        Designation = c.String(),
                        Address = c.String(),
                        Email = c.String(),
                        MobileNo = c.String(),
                        UserId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserInfoes", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MobileNo = c.String(),
                        FacebookId = c.String(),
                        FacebookOTP = c.Int(),
                        SkypeId = c.String(),
                        SkypeOTP = c.Int(),
                        SlackId = c.String(),
                        SlackOTP = c.Int(),
                        WebOTP = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LeaveBalances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TotalCasualLeave = c.Int(nullable: false),
                        TotalSickLeave = c.Int(nullable: false),
                        TotalAnnualLeave = c.Int(nullable: false),
                        AvailedCasualLeave = c.Int(nullable: false),
                        AvailedSickLeave = c.Int(nullable: false),
                        AvailedAnnualLeave = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        OneTimePassword = c.String(),
                        MobileNumber = c.String(),
                        TemporaryMobileNumber = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LeaveBalances", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Employees", "UserId", "dbo.UserInfoes");
            DropIndex("dbo.LeaveBalances", new[] { "EmployeeId" });
            DropIndex("dbo.Employees", new[] { "UserId" });
            DropTable("dbo.Users");
            DropTable("dbo.LeaveBalances");
            DropTable("dbo.UserInfoes");
            DropTable("dbo.Employees");
        }
    }
}
