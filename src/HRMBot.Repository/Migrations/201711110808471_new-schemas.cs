namespace HRMBot.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newschemas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        Address = c.String(),
                        MobileNo = c.String(),
                        UserInfoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserInfoes", t => t.UserInfoId, cascadeDelete: true)
                .Index(t => t.UserInfoId);
            
            CreateTable(
                "dbo.UserInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MobileNo = c.String(),
                        FacebookId = c.String(),
                        FacebookOTP = c.Int(nullable: false),
                        SkypeId = c.String(),
                        SkypeOTP = c.Int(nullable: false),
                        SlackId = c.String(),
                        SlackOTP = c.Int(nullable: false),
                        WebOTP = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LeaveBalances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        CasualLeaveBalance = c.Int(nullable: false),
                        SickLeaveBalance = c.Int(nullable: false),
                        AnnualLeaveBalance = c.Int(nullable: false),
                        AvailedLeave = c.Int(nullable: false),
                        AvailedSickLeave = c.Int(nullable: false),
                        AvailedAnnualLeave = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "UserInfoId", "dbo.UserInfoes");
            DropIndex("dbo.Employees", new[] { "UserInfoId" });
            DropTable("dbo.LeaveBalances");
            DropTable("dbo.UserInfoes");
            DropTable("dbo.Employees");
        }
    }
}
