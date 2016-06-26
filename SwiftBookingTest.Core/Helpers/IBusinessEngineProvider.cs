using SwiftBookingTest.CoreContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftBookingTest.Core.Helpers
{
    public interface IBusinessEngineProvider
    {
        T GetBusinessEngine<T>() where T : IBusinessEngine;
    }
}
