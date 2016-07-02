using StructureMap;
using StructureMap.Graph;
using System.Linq;
using StructureMap.Graph.Scanning;
using StructureMap.TypeRules;
using System.Web.Mvc;
using StructureMap.Pipeline;

namespace SwiftBookingTest.Web.Infrastructure
{
    public class MvcControllerConvention : IRegistrationConvention
    {
        public void ScanTypes(TypeSet types, Registry registry)
        {
            foreach (var type in types.AllTypes().Where(x => x.CanBeCastTo(typeof(Controller)) && !x.IsAbstract))
            {
                if (type.CanBeCastTo(typeof(Controller)) && !type.IsAbstract)
                {
                    registry.For(type).LifecycleIs(new UniquePerRequestLifecycle());
                }
            }

        }
    }
}