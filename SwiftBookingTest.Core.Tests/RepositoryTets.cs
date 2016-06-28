using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SwiftBookingTest.Core.Repository;
using SwiftBookingTest.Model;
using System.Linq;
using System.Data.Entity;
using SwiftBookingTest.CoreContracts;
using SwiftBookingTest.Core.Helpers;

namespace SwiftBookingTest.Core.Tests
{
    /// <summary>
    /// Summary description for RepositoryTets
    /// </summary>
    [TestClass]
    public class RepositoryTets : BaseUnitTest
    {
        public List<ClientRecord> list { get; set; } = new List<ClientRecord>();
        public Tuple<Mock<DbSet<ClientRecord>>, Mock<SwiftDemoContext>> returnSet { get; set; }
        public RepositoryTets()
        {
            var list = new List<ClientRecord>();
            list.Add(new ClientRecord { Id = 1 });
            returnSet = GetMockDbSetAndContext<ClientRecord, SwiftDemoContext>(list.AsQueryable());
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void GetAllTest()
        {

            returnSet = GetMockDbSetAndContext<ClientRecord, SwiftDemoContext>(list.AsQueryable());
            var dbContext = returnSet.Item2;
            var dbset = returnSet.Item1;
            var repo = new Mock<Repository<ClientRecord>>();

            dbContext.Setup(x => x.Set<ClientRecord>()).Returns(dbset.Object);
            repo.Setup(x => x.GetAll()).Returns(list.AsQueryable());
            Repository<ClientRecord> conRepo = new Repository<ClientRecord>(dbContext.Object);


            var dataList = conRepo.GetAll();
            Assert.IsTrue(list.SequenceEqual(dataList));
        }

        [TestMethod]
        public void AddTest()
        {

            returnSet = GetMockDbSetAndContext<ClientRecord, SwiftDemoContext>(list.AsQueryable());
            var dbContext = returnSet.Item2;
            var dbset = returnSet.Item1;
            var repo = new Mock<Repository<ClientRecord>>();
            var newCr = new ClientRecord { Id = 0, Name = "Atul" };

            var factoryMock = new Mock<IRepositoryProvider>();
            var uowMock = new Mock<ISwiftDemoUow>();
            var repositoryMock = new Mock<IRepository<ClientRecord>>();


            factoryMock.Setup(f => f.GetRepositoryForEntityType<ClientRecord>()).Returns(repositoryMock.Object);
            uowMock.Setup(u => u.ClientRecords).Returns(repositoryMock.Object);
            uowMock.Setup(u => u.Commit());

            dbContext.Setup(x => x.Set<ClientRecord>()).Returns(dbset.Object);
            dbset.Setup(x => x.Add(newCr));
            repo.Setup(x => x.Add(newCr));


            repositoryMock.Setup(x => x.Add(newCr));
            repositoryMock.Object.Add(newCr);
            uowMock.Object.Commit();

            // Assert
            repositoryMock.Verify(r => r.Add(newCr), Times.Once);
            repositoryMock.Verify(t => t.Add(newCr));
            repositoryMock.Verify(t => t.Add(It.Is<ClientRecord>(x => x.Name == "Atul")));
            uowMock.Verify(u => u.Commit(), Times.Once);

        }

        public void UpdateTest()
        {
            var dbContext = returnSet.Item2;
            var dbset = returnSet.Item1;
            var repo = new Mock<Repository<ClientRecord>>();
            var newCr = new ClientRecord { Id = 1, Name = "Atul" };

            var uowFactoryMock = new Mock<IRepositoryProvider>();
            var uowMock = new Mock<ISwiftDemoUow>();
            var repositoryMock = new Mock<IRepository<ClientRecord>>();

            //uowFactoryMock.Setup(x => x.GetRepositoryForEntityType<ClientRecord>()).Returns(repositoryMock.Object);
            //uowMock.Setup

        }
    }
}
