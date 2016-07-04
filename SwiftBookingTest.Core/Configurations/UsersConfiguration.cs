using SwiftBookingTest.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftBookingTest.Core.Configurations
{
    public class UsersConfiguration : EntityTypeConfiguration<Users>
    {
        public UsersConfiguration()
        {
            Property(x => x.FirstName).IsRequired();
            Property(x => x.EmailAddress).IsRequired();
            Property(x => x.Password).IsRequired();
        }
    }
}
