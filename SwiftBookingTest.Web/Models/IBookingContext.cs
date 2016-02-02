using System.Data.Entity;

namespace SwiftBookingTest.Web.Models
{
    public interface IBookingContext
    {
        DbSet<ClientRecord> ClientRecords { get; set; }

        int SaveChanges();
        Database Database { get; }
    }
}