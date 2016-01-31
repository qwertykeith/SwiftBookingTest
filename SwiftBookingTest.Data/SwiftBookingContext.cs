using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using SwiftBookingTest.Data.Model;

namespace SwiftBookingTest.Data
{
    public class SwiftBookingContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }

        public SwiftBookingContext()
            : base("SwiftBookingContext")
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
