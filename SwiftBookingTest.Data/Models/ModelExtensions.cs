using System;
using SwiftBookingTest.Core.Clients;
using SwiftBookingTest.Data.Models;

namespace SwiftBookingTest.Data
{
    public static class ModelExtensions
    {
        public static Client ToClient(this ClientDataModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException("model");
            }

            return new Client
            {
                Id = model.Id,
                Name = model.Name,
                Phone = model.Phone,
                Address = model.Address
            };
        }

        public static ClientDataModel ToDataModel(this Client client)
        {
            if (client == null)
            {
                throw new ArgumentNullException("client");
            }

            return new ClientDataModel
            {
                Id = client.Id,
                Name = client.Name,
                Phone = client.Phone,
                Address = client.Address
            };
        }
    }
}
