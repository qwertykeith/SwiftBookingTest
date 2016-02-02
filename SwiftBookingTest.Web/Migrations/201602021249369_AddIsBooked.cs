namespace SwiftBookingTest.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsBooked : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ClientRecords", "IsBooked", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ClientRecords", "IsBooked");
        }
    }
}
