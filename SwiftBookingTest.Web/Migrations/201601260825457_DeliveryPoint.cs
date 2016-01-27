namespace SwiftBookingTest.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeliveryPoint : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DeliveryPoint", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.DeliveryPoint", "Address", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DeliveryPoint", "Address", c => c.String());
            AlterColumn("dbo.DeliveryPoint", "Name", c => c.String());
        }
    }
}
