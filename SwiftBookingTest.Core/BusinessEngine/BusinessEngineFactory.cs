using SwiftBookingTest.CoreContracts.BusinessEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwiftBookingTest.CoreContracts;

namespace SwiftBookingTest.Core.BusinessEngine
{
    public class BusinessEngineFactory : IBusinessEngineFactory
    {
        private readonly IDictionary<Type,  object> BusinessEngines;
        public BusinessEngineFactory()
        {
            if (BusinessEngines == null)
                BusinessEngines = GetSwiftDemoFactories();
        }

        private IDictionary<Type,  object> GetSwiftDemoFactories()
        {
            return new Dictionary<Type,  object>
            {
            };
        }

        public T GetBusinessEngine<T>() where T : IBusinessEngine
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
