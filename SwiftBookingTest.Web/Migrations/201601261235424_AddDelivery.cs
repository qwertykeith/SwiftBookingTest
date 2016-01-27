namespace SwiftBookingTest.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDelivery : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Delivery",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BookingMessage = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Delivery");
        }
    }
}
