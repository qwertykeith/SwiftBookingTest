using System;
using System.Collections.Generic;
using System.Linq;
using SwiftBookingTest.Core.Clients;

namespace SwiftBookingTest.Data
{
    public class SwiftStorage : IClientStorage
    {
        private readonly SwiftDataContext _db = new SwiftDataContext();

        public SwiftStorage()
        {
            
        }
        
        public IEnumerable<Client> GetAllClients()
        {
            return _db.Clients
                .Select(x => new Client
                {
                    Id = x.Id,
                    Name = x.Name,
                    Phone = x.Phone,
                    Address = x.Address
                }).ToList();
        }

        public Client GetClient(Guid id)
        {
            return _db.Clients.SingleOrDefault(x => x.Id == id).ToClient();
        }

        public void InsertClient(Client client)
        {
            if (client == null)
            {
                throw new ArgumentNullException("client");
            }

            _db.Clients.Add(client.ToDataModel());
            _db.SaveChanges();
        }

        public void UpdateClient(Client client)
        {
            throw new NotImplementedException();
        }

        public void DeleteClient(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
