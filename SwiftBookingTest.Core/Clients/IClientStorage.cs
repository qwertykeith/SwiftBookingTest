using System;
using System.Collections.Generic;

namespace SwiftBookingTest.Core.Clients
{
    public interface IClientStorage
    {
        Client GetClient(Guid id);
        IEnumerable<Client> GetAllClients();
        void InsertClient(Client client);
        void UpdateClient(Client client);
        void DeleteClient(Guid id);
    }
}
