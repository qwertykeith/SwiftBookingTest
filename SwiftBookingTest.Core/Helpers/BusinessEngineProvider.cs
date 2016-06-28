using SwiftBookingTest.Core.BusinessEngine;
using SwiftBookingTest.CoreContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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

        /// <summary>
        /// The repository unit of work as we need to connect to database 
        /// </summary>

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
        /// <param name="uow">The uow.</param>
        /// <returns></returns>
        protected virtual T MakeBusinessEngine<T>()
        {
            try
            {
                object o = Activator.CreateInstance(typeof(T));
                BusinessEngines[typeof(T)] = (T)o;
                return (T)o;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
