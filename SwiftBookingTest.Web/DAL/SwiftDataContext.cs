using System.Data.Entity;
using SwiftBookingTest.Web.Models;

namespace SwiftBookingTest.Web.DAL
{
    /// <summary>
    /// The following is the datacontext for the test application
    /// Currently we are only storing one entity - Bookings.
    /// </summary>
    public class SwiftDataContext : DbContext
    {
        public SwiftDataContext()
            : base("SwiftDataContext")
        {
            //Assuming a basic structure for the purposes of this test
        }

        public DbSet<BookingDataModel> Bookings { get; set; }
    }
}
