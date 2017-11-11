namespace HRMBot.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixrelationship : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "UserInfoId", "dbo.UserInfoes");
            DropIndex("dbo.Employees", new[] { "UserInfoId" });
            AddColumn("dbo.UserInfoes", "EmployeeId", c => c.Int(nullable: false));
            CreateIndex("dbo.UserInfoes", "EmployeeId");
            AddForeignKey("dbo.UserInfoes", "EmployeeId", "dbo.Employees", "Id", cascadeDelete: true);
            DropColumn("dbo.Employees", "UserInfoId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "UserInfoId", c => c.Int(nullable: false));
            DropForeignKey("dbo.UserInfoes", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.UserInfoes", new[] { "EmployeeId" });
            DropColumn("dbo.UserInfoes", "EmployeeId");
            CreateIndex("dbo.Employees", "UserInfoId");
            AddForeignKey("dbo.Employees", "UserInfoId", "dbo.UserInfoes", "Id", cascadeDelete: true);
        }
    }
}
