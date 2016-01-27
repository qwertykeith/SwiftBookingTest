using SwiftBookingTest.Web.Data;
using SwiftBookingTest.Web.Models;
using SwiftBookingTest.Web.Swift;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;

namespace SwiftBookingTest.Web.Services
{
    public class DeliveryService
    {
        ISwiftConnector swiftConnector;
        IDeliveryDataAccessor deliveryDataAccessor;

        public DeliveryService(ISwiftConnector swiftConnector, IDeliveryDataAccessor deliveryDataAccessor)
        {
            this.swiftConnector = swiftConnector;
            this.deliveryDataAccessor = deliveryDataAccessor;
        }

        public async Task<int> BookDeliveryAsync(int deliveryPointId)
        {
            var deliveryPoint = deliveryDataAccessor.GetDeliveryPointById(deliveryPointId);
            var pickupPoint = new DeliveryPoint() { Address = "10 Downing Street, London", Name = "David Cameron", Phone = "0818118181" };
            var result = await swiftConnector.BookDeliveryAsync(pickupPoint, deliveryPoint);

            string message;
            message = TryPrettyPrintJson(result, out message) ? message : result;
                        
            var delivery = new Delivery() { BookingMessage = message };
            var newDeliveryId = deliveryDataAccessor.AddDelivery(delivery);
            return newDeliveryId;
        }

        private bool TryPrettyPrintJson(string json, out string prettyJson)
        {
            try
            {
                var obj = JsonConvert.DeserializeObject(json);
                prettyJson = JsonConvert.SerializeObject(obj, Formatting.Indented);
            }
            catch (Exception e)
            {
                prettyJson = "";
                return false;
            }
            return true;
        }
    }
}