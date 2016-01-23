using System;
using SwiftBookingTest.Core.Clients.ServiceModels;
using SwiftBookingTest.Core.Common;

namespace SwiftBookingTest.Core.Clients
{
    public class ClientService : ServiceBase, IClientService
    {
        private readonly IClientStorage _storage;

        public ClientService(IClientStorage storage)
            : base()
        {
            if (storage == null)
            {
                throw new ArgumentNullException("storage");
            }

            _storage = storage;
        }

        public CreateClientResponse CreateClient(CreateClientRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            var response = new CreateClientResponse();

            try
            {
                var client = new Client();
                client.Id = Guid.NewGuid();
                client.Name = request.Name;
                client.Phone = request.Phone;
                client.Address = request.Address;

                EnsureValid(client);

                _storage.InsertClient(client);

                response.Client = client;
            }
            catch (Exception ex)
            {
                response.Exception = ex;
            }

            return response;
        }

        public GetClientResponse GetClient(GetClientRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            var response = new GetClientResponse();

            try
            {
                var client = _storage.GetClient(request.Id);
                
                if (client == null)
                {
                    throw new NotFoundException();
                }

                response.Client = client;
            }
            catch (Exception ex)
            {
                response.Exception = ex;
            }

            return response;
        }

        public GetClientsResponse GetClients()
        {
            var response = new GetClientsResponse();

            try
            {
                var clients = _storage.GetAllClients();

                response.Clients = clients;
            }
            catch (Exception ex)
            {
                response.Exception = ex;
            }

            return response;
        }
    }
}
