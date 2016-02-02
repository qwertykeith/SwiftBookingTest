using System.Data.Entity;
using SwiftBookingTest.Web.Configuration;

namespace SwiftBookingTest.Web.Models
{
    public class BookingContext : DbContext, IBookingContext
    {
        public BookingContext(BookingConnectionStringSetting connectionString)
            : base(connectionString)
        {
        }

        public DbSet<ClientRecord> ClientRecords { get; set; }
    }
}