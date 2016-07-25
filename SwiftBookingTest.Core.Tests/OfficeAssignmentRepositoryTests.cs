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
    public class OfficeAssignmentRepositoryTests : BaseUnitTest
    {
        public List<OfficeAssignment> list { get; set; } = new List<OfficeAssignment>();
        public ClientRecord cr { get; set; } = new ClientRecord { };
        public Instructor inst { get; set; } = new Instructor { InstructorID = 1 };


        public OfficeAssignmentRepositoryTests()
        {
            list.Add(new OfficeAssignment { InstructorID = 1 });
        }

        [TestMethod]
        public void GetByInstructorTest()
        {
            //tHESE ARE DEPENDENCY FOR CUSTOM REPO
            var businessEngine = new Mock<ISwiftBookingBusinessEngineUow>();
            var returnSet = GetMockDbSetAndContext<OfficeAssignment, SwiftDemoContext>(list.AsQueryable());
            var dbContext = returnSet.Item2;
            var dbset = returnSet.Item1;

            //DEPENDENCY ENDS HERE

            //MOCK REPO
            var repo = new Mock<IOfficeAssignmentRepository>();
            //SET UP THE DBCONTEXT THIS SETS THE DBSET OBJECT
            dbContext.Setup(x => x.Set<OfficeAssignment>()).Returns(dbset.Object);
            //SET BUSINESS RULE
            businessEngine.Setup(x => x.ClientRecordBusinessValidatiors.IsNull(cr, false)).Returns(true);
            businessEngine.Setup(x => x.PhoneNumberBusinessValidatiors.IsNull(null, false)).Returns(false);

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

        //[TestMethod]
        //public void GetByIdTests()
        //{
        //    OfficeAssignment officeAssignment = new OfficeAssignment
        //    {
        //        InstructorID = 1
        //    };
        //    Mock<IOfficeAssignmentRepository> mockOfficeRepo = new Mock<IOfficeAssignmentRepository>();
        //    Mock<ISwiftDemoUow> mockSwiftDemo = new Mock<ISwiftDemoUow>();
        //    Mock<SwiftDemoContext> mockSwiftDemoContext = new Mock<SwiftDemoContext>();
        //    Mock<DbSet<OfficeAssignment>> dbset = new Mock<DbSet<OfficeAssignment>>();

        //    mockOfficeRepo.Setup(x => x.GetBySomeId(1)).Returns(officeAssignment);
        //    mockSwiftDemo.Setup(x => x.OfficeAssignments).Returns(mockOfficeRepo.Object);
        //    mockSwiftDemoContext.Setup(x => x.Set<OfficeAssignment>()).Returns(dbset.Object);
        //    dbset.Setup(x => x.Find(1)).Returns(officeAssignment);

        //    OfficeAssignmentRepository repo = new OfficeAssignmentRepository(mockSwiftDemoContext.Object);

        //    var assignment = repo.GetBySomeId(1);
        //    Assert.IsTrue(assignment.InstructorID == 1);
        //}


    }
}
