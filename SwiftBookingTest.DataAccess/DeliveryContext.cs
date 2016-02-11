using SwiftBookingTest.DataAccess.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SwiftBookingTest.DataAccess
{
    public class DeliveryContext : DbContext
    {
        public DeliveryContext() : base("name=DeliveryConnection")
        {
            Database.SetInitializer<DeliveryContext>(new CreateDatabaseIfNotExists<DeliveryContext>());
        }

        public DbSet<DeliveryDetails> Deliveries { get; set; }
    }
}
