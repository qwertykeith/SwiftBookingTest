using SwiftBookingTest.Core.Clients.ServiceModels;

namespace SwiftBookingTest.Core.Clients
{
    public interface IClientService
    {
        CreateClientResponse CreateClient(CreateClientRequest request);
        GetClientsResponse GetClients();
        GetClientResponse GetClient(GetClientRequest request);
    }
}
