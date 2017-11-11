namespace HRMBot.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class designationandseeddata : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Designation", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "Designation");
        }
    }
}
