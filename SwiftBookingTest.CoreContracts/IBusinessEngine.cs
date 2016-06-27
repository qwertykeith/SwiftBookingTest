using SwiftBookingTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftBookingTest.CoreContracts
{
    public interface IBusinessEngine
    {
        /// <summary>
        /// Determines whether the specified entity is null.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="checkId">if set to <c>true</c> [check identifier].</param>
        /// <returns></returns>
        bool IsNull(BaseClass entity, bool checkId = false);
    }
}
