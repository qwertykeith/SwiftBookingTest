using SwiftBookingTest.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftBookingTest.Core.Configurations
{
    public class OfficeAssignmentConfiguration : EntityTypeConfiguration<OfficeAssignment>
    {
        public OfficeAssignmentConfiguration()
        {
            //HasKey(t => t.InstructorID);
        }
    }
}
