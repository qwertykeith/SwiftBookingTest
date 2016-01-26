using System;
using System.Linq;
using SwiftBookingTest.CoreContracts;
using SwiftBookingTest.Model;
using System.Collections.Generic;

namespace SwiftBookingTest.Web.Test.Fakes
{
    internal class FakeClientRecordRepository : IRepository<ClientRecord>
    {
        public void Add(ClientRecord entity)
        {

        }

        public void Delete(int id)
        {

        }

        public void Delete(ClientRecord entity)
        {

        }

        public IQueryable<ClientRecord> GetAll()
        {
            return new List<ClientRecord>
            {
                new ClientRecord
                {
                    Address = "Am i good",
                    ClientPhones = new List<ClientPhone>
                    {
                        new ClientPhone
                        {
                            ClientRecordId =1,
                            PhoneNumberId =1,
                            PhoneNumber = new PhoneNumber { Number="123456"},
                            Id =1
                        },
                        new ClientPhone
                        {
                            ClientRecordId =2,
                            PhoneNumberId =2,
                            PhoneNumber = new PhoneNumber { Number="654321"},
                            Id =2
                        }
                    },
                    Id =1,
                    Name ="Atul",
                }
            }.AsQueryable();
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