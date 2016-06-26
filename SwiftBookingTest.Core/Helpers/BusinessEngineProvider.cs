using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwiftBookingTest.CoreContracts;

namespace SwiftBookingTest.Core.Helpers
{
    public class BusinessEngineProvider : IBusinessEngineProvider
    {
        /// <summary>
        /// The _repository factories
        /// </summary>
        private BusinessEngineFactory _businessFactories;

        /// <summary>
        /// Gets the business engines.
        /// </summary>
        /// <value>
        /// The business engines.
        /// </value>
        protected Dictionary<Type, object> BusinessEngines { get; private set; }

        public BusinessEngineProvider(BusinessEngineFactory businessEngineFactory)
        {
            _businessFactories = businessEngineFactory;
            BusinessEngines = new Dictionary<Type, object>();
        }

        public virtual T GetBusinessEngine<T>() where T : IBusinessEngine
        {
            object businessObj;
            BusinessEngines.TryGetValue(typeof(T), out businessObj);
            if (businessObj != null)
                return (T)businessObj;

            return MakeBusinessEngine<T>();
        }

        /// <summary>
        /// Makes the business engine.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="factory">The factory.</param>
        /// <param name="dbContext">The database context.</param>
        /// <returns></returns>
        protected virtual T MakeBusinessEngine<T>()
        {
            object o = Activator.CreateInstance<T>();
            BusinessEngines[typeof(T)] = (T)o;
            return (T)o;
        }
    }
}
