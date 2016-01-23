using System.Data.Entity;
using SwiftBookingTest.Data.Models;

namespace SwiftBookingTest.Data
{
    public class SwiftDataContext : DbContext
    {
        public SwiftDataContext()
            : base("DefaultConnection")
        {
            Configuration.AutoDetectChangesEnabled = true;
            Configuration.LazyLoadingEnabled = true;
            Configuration.ValidateOnSaveEnabled = true;
        }

        public IDbSet<ClientDataModel> Clients { get; set; }
    }
}
