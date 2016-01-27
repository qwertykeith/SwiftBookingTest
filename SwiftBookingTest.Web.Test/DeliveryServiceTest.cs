using NUnit.Framework;
using Rhino.Mocks;
using SwiftBookingTest.Web.Data;
using SwiftBookingTest.Web.Models;
using SwiftBookingTest.Web.Services;
using SwiftBookingTest.Web.Swift;
using SwiftBookingTest.Web.Swift.MessageTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftBookingTest.Web.Test
{
    [TestFixture]
    public class DeliveryServiceTest
    {
        [Test]
        public void ItRequestsDeliveryToCorrectAddress()
        {
            // Arrange
            var deliveryAddress = "Correct Address";
            var apiKey = Guid.Empty;
            var mockDataAccessor = MockRepository.GenerateStub<IDeliveryDataAccessor>();
            mockDataAccessor.Stub(x => x.GetDeliveryPointById(1)).Return(new DeliveryPoint(){Address=deliveryAddress});
            var mockSwiftConnector = MockRepository.GenerateMock<ISwiftConnector>();
            mockSwiftConnector.Expect(x => x.BookDeliveryAsync(Arg<DeliveryPoint>.Is.Anything, Arg<DeliveryPoint>.Matches(dp => dp.Address == deliveryAddress))).Return(Task.FromResult("{}"));
            var deliveryService = new DeliveryService(mockSwiftConnector, mockDataAccessor);
            //Act
            var result = deliveryService.BookDeliveryAsync(1);

            //Assert
            mockSwiftConnector.VerifyAllExpectations();
        }

        [Test]
        public void ItPrettyPrintsResult()
        {
            // Arrange
            var deliveryAddress = "Correct Address";
            Delivery delivery = null;
            var apiKey = Guid.Empty;
            var mockDataAccessor = MockRepository.GenerateStub<IDeliveryDataAccessor>();
            mockDataAccessor.Stub(x => x.GetDeliveryPointById(1)).Return(new DeliveryPoint() { Address = deliveryAddress });
            mockDataAccessor.Stub(x => x.AddDelivery(Arg<Delivery>.Is.Anything))
                .Do((Func<Delivery,int>)((d) => 
                    {
                        delivery = d;
                        return 1;
                    }));
            var mockSwiftConnector = MockRepository.GenerateMock<ISwiftConnector>();
            mockSwiftConnector.Expect(x => x.BookDeliveryAsync(Arg<DeliveryPoint>.Is.Anything, Arg<DeliveryPoint>.Matches(dp => dp.Address == deliveryAddress))).Return(Task.FromResult(@"{""foo"":""bar""}"));
            var deliveryService = new DeliveryService(mockSwiftConnector, mockDataAccessor);
            //Act
            var result = deliveryService.BookDeliveryAsync(1).Result;

            //Assert
            Assert.That(delivery, Is.Not.Null);
            Assert.That(delivery.BookingMessage.IndexOf("\n"), Is.GreaterThanOrEqualTo(0));
            Assert.That(result, Is.EqualTo(1));
        }
    }
}
