using StructureMap;
using StructureMap.Graph;

namespace SwiftBookingTest.Web.Infrastructure
{
    public class ControllerRegisrty:Registry
    {
        public ControllerRegisrty()
        {
            Scan((scan) =>
            {
                scan.TheCallingAssembly();
                scan.With(new ControllerConvention());
            });
        }
    }
}