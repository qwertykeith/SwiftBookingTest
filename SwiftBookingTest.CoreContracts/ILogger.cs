using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftBookingTest.CoreContracts
{
    public interface ILogger
    {
        void CreateAudit(string description);
    }
}
