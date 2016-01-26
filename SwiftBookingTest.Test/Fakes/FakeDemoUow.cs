using SwiftBookingTest.CoreContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwiftBookingTest.Model;

namespace SwiftBookingTest.Web.Test.Fakes
{

    public class FakeDemoUow : ISwiftDemoUow
    {
        
        public IRepository<ClientPhone> ClientPhones
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IRepository<ClientRecord> ClientRecords
        {
            get
            {
                return new FakeClientRecordRepository();
            }
        }

        public IRepository<PhoneNumber> PhoneNumbers
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Add(ClientRecord entity)
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            //done all good
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(ClientRecord entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ClientRecord> GetAll()
        {
            throw new NotImplementedException();
        }

        public ClientRecord GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(ClientRecord entity)
        {
            throw new NotImplementedException();
        }
    }
}
