using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
