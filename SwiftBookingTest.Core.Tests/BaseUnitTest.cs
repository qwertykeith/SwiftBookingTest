using Moq;
using System;
using System.Data.Entity;
using System.Linq;

namespace SwiftBookingTest.Core.Tests
{
    public abstract class BaseUnitTest
    {
        /// <summary>
        /// Gets the mock database(as Item1) set and context(as item2).
        /// </summary>
        /// <typeparam name="T">DbSet</typeparam>
        /// <typeparam name="T2">The type of the 2 is dbcontext/typeparam>
        /// <param name="entities">The entities.</param>
        /// <returns>Tuple of DBSet and DBContext</returns>
        public virtual Tuple<Mock<DbSet<T>>, Mock<SwiftDemoContext>> GetMockDbSetAndContext<T, T2>(IQueryable<T> entities) where T : class, new() where T2 : class
        {
            var dbContext = new Mock<SwiftDemoContext>();

            var mockSet = new Mock<DbSet<T>>();
            mockSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(entities.Provider);
            mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(entities.Expression);
            mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(entities.ElementType);
            mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(entities.GetEnumerator());
            return new Tuple<Mock<DbSet<T>>, Mock<SwiftDemoContext>>(mockSet, dbContext);
        }
    }
}