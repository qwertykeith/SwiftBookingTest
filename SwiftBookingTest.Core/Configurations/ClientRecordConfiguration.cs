using SwiftBookingTest.Model;
using System.Data.Entity.ModelConfiguration;

namespace SwiftBookingTest.Core.Configurations
{
    /// <summary>
    /// Business rules for Client record class
    /// </summary>
    /// <seealso cref="System.Data.Entity.ModelConfiguration.EntityTypeConfiguration{SwiftBookingTest.Model.ClientRecord}" />
    public class ClientRecordConfiguration : EntityTypeConfiguration<ClientRecord>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClientRecordConfiguration"/> class.
        /// </summary>
        public ClientRecordConfiguration()
        {
            //Property(x => x.Name).IsRequired().HasMaxLength(150);
            //Property(x => x.Name).IsRequired().HasMaxLength(1000);
            
        }
        
    }
}
