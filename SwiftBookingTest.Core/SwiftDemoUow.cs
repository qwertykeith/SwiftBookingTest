using SwiftBookingTest.Core.Helpers;
using SwiftBookingTest.Core.Repository;
using SwiftBookingTest.CoreContracts;
using SwiftBookingTest.Model;
using System;

namespace SwiftBookingTest.Core
{
    public class SwiftDemoUow : ISwiftDemoUow, IDisposable
    {
        //public SwiftDemoUow(IRepositoryProvider repositoryProvider)
        //{
        //    CreateDbContext();
        //    repositoryProvider.DbContext = DbContext;
        //    RepositoryProvider = repositoryProvider;
        //}

        public SwiftDemoUow(IRepositoryProvider repositoryProvider, ISwiftBookingBusinessEngineUow businessUow)
        {
            CreateDbContext();
            repositoryProvider.DbContext = DbContext;
            RepositoryProvider = repositoryProvider;
            repositoryProvider.SwiftBookingBusinessEngineUow = businessUow;
        }

        private SwiftDemoContext DbContext { get; set; }


        // Code Camper repositories

        /// <summary>
        /// Gets the client records.
        /// </summary>
        /// <value>
        /// The client records.
        /// </value>
        public IRepository<ClientRecord> ClientRecords { get { return GetStandardRepo<ClientRecord>(); } }
        
        /// <summary>
        /// Gets the client phones.
        /// </summary>
        /// <value>
        /// The client phones.
        /// </value>
        public IRepository<ClientPhone> ClientPhones { get { return GetStandardRepo<ClientPhone>(); } }
        
        /// <summary>
        /// Gets the phone numbers.
        /// </summary>
        /// <value>
        /// The phone numbers.
        /// </value>
        public IRepository<PhoneNumber> PhoneNumbers { get { return GetStandardRepo<PhoneNumber>(); } }

        /// <summary>
        /// Gets the phone numbers.
        /// </summary>
        /// <value>
        /// The phone numbers.
        /// </value>
        public IRepository<Student> Students { get { return GetStandardRepo<Student>(); } }

        /// <summary>
        /// Gets the courses.
        /// </summary>
        /// <value>
        /// The courses.
        /// </value>
        public IRepository<Coarse> Coarses { get { return GetStandardRepo<Coarse>(); } }

        /// <summary>
        /// Gets the instructors.
        /// </summary>
        /// <value>
        /// The instructors.
        /// </value>
        public IRepository<Instructor> Instructors { get { return GetStandardRepo<Instructor>(); } }

        /// <summary>
        /// Gets the office assignments.
        /// </summary>
        /// <value>
        /// The office assignments.
        /// </value>
        public IOfficeAssignmentRepository OfficeAssignments { get { return GetRepo<OfficeAssignmentRepository>(); } }

        /// <summary>
        /// Save pending changes to the database
        /// </summary>
        public void Commit()
        {
            //System.Diagnostics.Debug.WriteLine("Committed");
            DbContext.SaveChanges();
        }

        protected void CreateDbContext()
        {
            DbContext = new SwiftDemoContext();

            // Do NOT enable proxied entities, else serialization fails
            DbContext.Configuration.ProxyCreationEnabled = false;

            // Load navigation properties explicitly (avoid serialization trouble)
            DbContext.Configuration.LazyLoadingEnabled = false;

            // Because Web API will perform validation, we don't need/want EF to do so
            //DbContext.Configuration.ValidateOnSaveEnabled = false;

        }

        protected IRepositoryProvider RepositoryProvider { get; set; }

        private IRepository<T> GetStandardRepo<T>() where T : class
        {
            return RepositoryProvider.GetRepositoryForEntityType<T>();
        }
        private T GetRepo<T>() where T : class
        {
            return RepositoryProvider.GetRepository<T>();
        }



        #region IDisposable

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (DbContext != null)
                {
                    DbContext.Dispose();
                }
            }
        }

        #endregion

    }
}
