namespace HRMBot.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewModelTempOtp : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TempOtps",
                c => new
                    {
                        TempOtpId = c.Int(nullable: false, identity: true),
                        ChannelId = c.String(),
                        Otp = c.String(),
                        FromId = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TempOtpId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TempOtps");
        }
    }
}
