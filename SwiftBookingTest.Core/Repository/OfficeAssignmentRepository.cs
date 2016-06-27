using SwiftBookingTest.CoreContracts;
using SwiftBookingTest.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftBookingTest.Core.Repository
{
    public class OfficeAssignmentRepository : Repository<OfficeAssignment>, IOfficeAssignmentRepository
    {
        private ISwiftBookingBusinessEngineUow _businessUow;

        public OfficeAssignmentRepository(DbContext context) : base(context)
        {
        }

        public OfficeAssignmentRepository(DbContext context, ISwiftBookingBusinessEngineUow businessUow) : base(context)
        {
            _businessUow = businessUow;
        }

       
        /// <summary>
        /// Gets the by instructor.
        /// </summary>
        /// <param name="instructorId">The instructor identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IQueryable<OfficeAssignment> GetByInstructor(int instructorId)
        {

            //var pp = _businessUow.ClientRecordBusinessValidatiors.IsNull(new ClientRecord { });
            //var pp2 = _businessUow.PhoneNumberBusinessValidatiors.IsNull(new PhoneNumber { });
            //var hij = _businessUow.SwiftDemoUow.Instructors.GetById(instructorId);
            return DbSet.Where(x => x.InstructorID == instructorId);
        }
    }
}
