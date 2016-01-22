using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwiftBookingTest.Core.Clients;

namespace SwiftBookingTest.Core.Storage
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
