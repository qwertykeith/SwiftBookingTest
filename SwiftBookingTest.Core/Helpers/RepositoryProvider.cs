using SwiftBookingTest.CoreContracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftBookingTest.Core.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="SwiftBookingTest.Core.Helpers.IRepositoryProvider" />
    public class RepositoryProvider : IRepositoryProvider
    {
        /// <summary>
        /// Gets the repositories.
        /// </summary>
        /// <value>
        /// The repositories.
        /// </value>
        protected Dictionary<Type, object> Repositories { get; private set; }

        /// <summary>
        /// The _repository factories
        /// </summary>
        private RepositoryFactories _repositoryFactories;

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryProvider"/> class.
        /// </summary>
        /// <param name="repositoryFactories">The repository factories.</param>
        public RepositoryProvider(RepositoryFactories repositoryFactories)
        {
            _repositoryFactories = repositoryFactories;
            Repositories = new Dictionary<Type, object>();
        }

        /// <summary>
        /// Get and set the <see cref="DbContext" /> with which to initialize a repository
        /// if one must be created.
        /// </summary>
        public DbContext DbContext { get; set; }

        /// <summary>
        /// Get an <see cref="IRepository{T}" /> for entity type, T.
        /// </summary>
        /// <typeparam name="T">Root entity type of the <see cref="IRepository{T}" />.</typeparam>
        /// <returns></returns>
        public IRepository<T> GetRepositoryForEntityType<T>() where T : class
        {
            return GetRepository<IRepository<T>>(
                _repositoryFactories.GetRepositoryFactoryForEntityType<T>());
        }

        /// <summary>
        /// Get a repository of type T.
        /// </summary>
        /// <typeparam name="T">Type of the repository, typically a custom repository interface.</typeparam>
        /// <param name="factory">An optional repository creation function that takes a <see cref="DbContext" />
        /// and returns a repository of T. Used if the repository must be created.</param>
        /// <returns></returns>
        /// <remarks>
        /// Looks for the requested repository in its cache, returning if found.
        /// If not found, tries to make one with the factory, fallingback to
        /// a default factory if the factory parameter is null.
        /// </remarks>
        public virtual T GetRepository<T>(Func<DbContext, object> factory = null) where T : class
        {
            // Look for T dictionary cache under typeof(T).
            object repoObj;
            Repositories.TryGetValue(typeof(T), out repoObj);
            if (repoObj != null)
            {
                return (T)repoObj;
            }

            // Not found or null; make one, add to dictionary cache, and return it.
            return MakeRepository<T>(factory, DbContext);
        }

        

        /// <summary>
        /// Makes the repository.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="factory">The factory.</param>
        /// <param name="dbContext">The database context.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException">No factory for repository type,  + typeof(T).FullName</exception>
        protected virtual T MakeRepository<T>(Func<DbContext, object> factory, DbContext dbContext)
        {
            var f = factory ?? _repositoryFactories.GetRepositoryFactory<T>();
            if (f == null)
            {
                throw new NotImplementedException("No factory for repository type, " + typeof(T).FullName);
            }
            var repo = (T)f(dbContext);
            Repositories[typeof(T)] = repo;
            return repo;
        }

        /// <summary>
        /// Set the repository to return from this provider.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="repository"></param>
        /// <remarks>
        /// Set a repository if you don't want this provider to create one.
        /// Useful in testing and when developing without a backend
        /// implementation of the object returned by a repository of type T.
        /// </remarks>
        public void SetRepository<T>(T repository)
        {
            Repositories[typeof(T)] = repository;
        }

       

    }
}
