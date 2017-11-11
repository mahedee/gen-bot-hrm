namespace HRMBot.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class madeUserInfoOptional : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Employees", new[] { "UserId" });
            AlterColumn("dbo.Employees", "UserId", c => c.Int());
            CreateIndex("dbo.Employees", "UserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Employees", new[] { "UserId" });
            AlterColumn("dbo.Employees", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Employees", "UserId");
        }
    }
}
