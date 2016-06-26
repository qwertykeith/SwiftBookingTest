using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftBookingTest.Core.Helpers
{
    public class BusinessEngineFactory
    {
        /// <summary>
        /// Gets the swift demo factories.
        /// </summary>
        /// <returns></returns>
        private IDictionary<Type, object> GetSwiftDemoBusinessEngine()
        {
            return new Dictionary<Type, object>
            {
                //add customised repository
            };
        }
        /// <summary>
        /// The _repository factories
        /// </summary>
        private readonly IDictionary<Type, object> _businessEngineFactories;

        public BusinessEngineFactory()
        {
            _businessEngineFactories = GetSwiftDemoBusinessEngine();
        }
        
    }
}
