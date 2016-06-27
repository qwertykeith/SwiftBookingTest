using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SwiftBookingTest.CoreContracts;
using SwiftBookingTest.Core;
using System.Data.Entity;
using SwiftBookingTest.Core.Repository;
using System.Linq;
using SwiftBookingTest.Model;
using System.Collections.Generic;

namespace SwiftBookingTest.Core.Tests
{
    [TestClass]
    public class OfficeAssignmentRepositoryTests
    {
        [TestMethod]
        public void GetByInstructorTest()
        {
            var cr = new ClientRecord();
            var inst = new Instructor { InstructorID = 1 };

            var list = new List<OfficeAssignment>();
            list.Add(new OfficeAssignment { InstructorID = 1 });

            //tHESE ARE DEPENDENCY FOR CUSTOM REPO
            var businessEngine = new Mock<ISwiftBookingBusinessEngineUow>();
            var dbContext = new Mock<SwiftDemoContext>();
            var dbset = GetMockDbSet<OfficeAssignment>(list.AsQueryable());
            //DEPENDENCY ENDS HERE

            //MOCK REPO
            var repo = new Mock<IOfficeAssignmentRepository>();
            //SET UP THE DBCONTEXT THIS SETS THE DBSET OBJECT
            dbContext.Setup(x => x.Set<OfficeAssignment>()).Returns(dbset.Object);
            //SET BUSINESS RULE
            businessEngine.Setup(x => x.ClientRecordBusinessValidatiors.IsNull(cr, false)).Returns(true);
            businessEngine.Setup(x => x.PhoneNumberBusinessValidatiors.IsNull(null, false)).Returns(false);
            businessEngine.Setup(x => x.SwiftDemoUow.Instructors.GetById(1)).Returns(inst);
            //SET TEST CALL 
            repo.Setup(x => x.GetByInstructor(1)).Returns(list.AsQueryable());
            //MAKE CALL
            OfficeAssignmentRepository conRepo = new OfficeAssignmentRepository(dbContext.Object, businessEngine.Object);
            //GET RESULT
            var data = conRepo.GetByInstructor(1);
            //COMPARE RESULT
            Assert.IsTrue(data.SequenceEqual(list));
            Assert.IsFalse(data.Where(x => x.InstructorID != 1).Count() > 0);
        }


        // a helper to make dbset queryable
        private Mock<DbSet<T>> GetMockDbSet<T>(IQueryable<T> entities) where T : class
        {
            var mockSet = new Mock<DbSet<T>>();
            mockSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(entities.Provider);
            mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(entities.Expression);
            mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(entities.ElementType);
            mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(entities.GetEnumerator());
            return mockSet;
        }
    }
}
