using SwiftBookingTest.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftBookingTest.Core.Helpers
{
    public class RepositoryFactories
    {
        /// <summary>
        /// Gets the swift demo factories.
        /// </summary>
        /// <returns></returns>
        private IDictionary<Type, Func<DbContext, object>> GetSwiftDemoFactories()
        {
            return new Dictionary<Type, Func<DbContext, object>>
            {
                //add customised repository
            };
        }
        /// <summary>
        /// The _repository factories
        /// </summary>
        private readonly IDictionary<Type, Func<DbContext, object>> _repositoryFactories;

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryFactories"/> class.
        /// </summary>
        public RepositoryFactories()
        {
            _repositoryFactories = GetSwiftDemoFactories();
        }

        /// <summary>
        /// Constructor that initializes with an arbitrary collection of factories
        /// </summary>
        /// <param name="factories">
        /// The repository factory functions for this instance. 
        /// </param>
        /// <remarks>
        /// This ctor is primarily useful for testing this class
        /// </remarks>
        public RepositoryFactories(IDictionary<Type, Func<DbContext, object>> factories)
        {
            _repositoryFactories = factories;
        }

        /// <summary>
        /// Get the repository factory function for the type.
        /// </summary>
        /// <typeparam name="T">Type serving as the repository factory lookup key.</typeparam>
        /// <returns>The repository function if found, else null.</returns>
        /// <remarks>
        /// The type parameter, T, is typically the repository type 
        /// but could be any type (e.g., an entity type)
        /// </remarks>
        public Func<DbContext, object> GetRepositoryFactory<T>()
        {

            Func<DbContext, object> factory;
            _repositoryFactories.TryGetValue(typeof(T), out factory);
            return factory;
        }

        /// <summary>
        /// Gets the type of the repository factory for entity.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public Func<DbContext, object> GetRepositoryFactoryForEntityType<T>() where T : class
        {
            return GetRepositoryFactory<T>() ?? DefaultEntityRepositoryFactory<T>();
        }

        /// <summary>
        /// Defaults the entity repository factory.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        protected virtual Func<DbContext, object> DefaultEntityRepositoryFactory<T>() where T : class
        {
            return dbContext => new Repository<T>(dbContext);
        }

        

    }
}
