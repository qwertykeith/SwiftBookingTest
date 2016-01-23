using System;
using System.Net.Http;
using System.Threading.Tasks;
using SwiftBookingTest.Core.Clients;
using SwiftBookingTest.Core.Clients.ServiceModels;
using SwiftBookingTest.Core.Common;
using SwiftBookingTest.Core.Swift.ServiceModels;

namespace SwiftBookingTest.Core.Swift
{
    public class SwiftService : ServiceBase, ISwiftService
    {
        private readonly SwiftApiSettings _settings;
        private readonly IClientService _clientService;

        public SwiftService(SwiftApiSettings settings, IClientService clientService)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            if (string.IsNullOrEmpty(settings.BaseAddress))
            {
                throw new ArgumentException("Cannot be null or empty", "settings.BaseUrl");
            }

            if (string.IsNullOrEmpty(settings.MerchantKey))
            {
                throw new ArgumentException("Cannot be null or empty", "settings.MerchantKey");
            }

            if (clientService == null)
            {
                throw new ArgumentNullException("clientService");
            }

            _settings = settings;
            _clientService = clientService;
        }

        public async Task<CreateDeliveryBookingResponse> CreateDeliveryBooking(CreateDeliveryBookingRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            var response = new CreateDeliveryBookingResponse();

            try
            {
                var clientResponse = _clientService.GetClient(new GetClientRequest(request.ClientId));

                if (!clientResponse.Success)
                {
                    response.Exception = clientResponse.Exception;

                    return response;
                }

                var httpClient = new HttpClient() { BaseAddress = new Uri(_settings.BaseAddress) };
                var requestContent = BuildDeliveryBookingRequestModel(clientResponse.Client, request.PickupDetail);

                var apiPath = request.ApiPath ?? string.Format("{0}/deliveries", _settings.ApiRoot);
                var apiResponse = await httpClient.PostAsJsonAsync(apiPath, requestContent);

                response.StatusCode = apiResponse.StatusCode;

                if (apiResponse.IsSuccessStatusCode)
                {
                    response.Content = await apiResponse.Content.ReadAsAsync<dynamic>();
                }
                else
                {
                    response.Exception = new HttpRequestException("An error occurred during the request to the Swift API");
                }
            }
            catch (Exception ex)
            {
                response.Exception = ex;
            }
            
            return response;            
        }

        private SwiftDeliveryBookingRequestModel BuildDeliveryBookingRequestModel(Client client, SwiftDeliveryDetail pickupDetail)
        {
            return new SwiftDeliveryBookingRequestModel
            {
                ApiKey = _settings.MerchantKey,
                Booking = new SwiftBooking
                {
                    PickupDetail = pickupDetail,
                    DropoffDetail = new SwiftDeliveryDetail
                    {
                        Name = client.Name,
                        Phone = client.Phone,
                        Address = client.Address
                    }
                }
            };
        }
    }
}
