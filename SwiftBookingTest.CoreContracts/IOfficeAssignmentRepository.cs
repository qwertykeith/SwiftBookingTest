using SwiftBookingTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftBookingTest.CoreContracts
{
    public interface IOfficeAssignmentRepository : IRepository<OfficeAssignment>
    {
        /// <summary>
        /// Gets the by instructor.
        /// </summary>
        /// <param name="instructorId">The instructor identifier.</param>
        /// <returns></returns>
        IQueryable<OfficeAssignment> GetByInstructor(int instructorId);
    }
}
