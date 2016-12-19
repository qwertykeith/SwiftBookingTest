using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StructureMap.Graph;

namespace SwiftBookingTest.Web.Infrastructure
{
    public class StandardRegisrty : Registry
    {
        public StandardRegisrty()
        {
            Scan(scan =>
            {
                scan.TheCallingAssembly();
                scan.WithDefaultConventions();
            });
        }
    }
}