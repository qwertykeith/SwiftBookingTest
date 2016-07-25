using SwiftBookingTest.CoreContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftBookingTest.Core
{
    public class DatabaseBusinessEngine : IDatabaseBusinessEngine
    {
        public DatabaseBusinessEngine(ISwiftDemoUow swiftDemoUow, ISwiftBookingBusinessEngineUow businessEngine)
        {

        }
    }
}
