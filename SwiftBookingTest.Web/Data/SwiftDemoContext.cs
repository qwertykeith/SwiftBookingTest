using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using SwiftBookingTest.Web.Models;

namespace SwiftBookingTest.Web.Data
{
    public class SwiftDemoContext : DbContext
    {
        public SwiftDemoContext()
            : base("SwiftDemo")
        { }

        public DbSet<DeliveryPoint> DeliveryPoints { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
