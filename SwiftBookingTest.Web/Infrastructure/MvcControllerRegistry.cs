using StructureMap;
using StructureMap.Graph;
using StructureMap.Configuration.DSL;

namespace SwiftBookingTest.Web.Infrastructure
{
    public class MvcControllerRegistry:Registry
    {
        public MvcControllerRegistry()
        {
            Scan(scan =>
            {
                scan.TheCallingAssembly();
                scan.With(new MvcControllerConvention());
            });
        }
    }
}