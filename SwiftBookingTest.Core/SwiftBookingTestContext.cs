using System.Data.Entity;

namespace SwiftBookingTest.Core
{
    public interface IContext
    {
        IDbSet<Person> Persons { get; set; }
        int SaveChanges();
    }

    public class SwiftBookingTestContext : DbContext, IContext
    {
        public IDbSet<Person> Persons { get; set; }
    }
}
