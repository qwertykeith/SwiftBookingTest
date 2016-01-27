using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwiftBookingTest.Web.Models;

namespace SwiftBookingTest.Web.Data
{

    public interface IDeliveryDataAccessor
    {
        DeliveryPoint GetDeliveryPointById(int deliveryPointId);
        IEnumerable<DeliveryPoint> GetDeliveryPoints();
        void AddDeliveryPoint(DeliveryPoint deliveryPoint);

        Delivery GetDeliveryById(int deliveryId);
        int AddDelivery(Delivery delivery);
    }

    public class DeliveryDataAccessor : IDeliveryDataAccessor
    {
        public DeliveryDataAccessor()
        {
        }
        public DeliveryPoint GetDeliveryPointById(int deliveryPointId)
        {
            using (var context = new Data.SwiftDemoContext())
            {
                return context.Set<DeliveryPoint>().FirstOrDefault(dp => dp.ID == deliveryPointId);
            }
        }

        public IEnumerable<DeliveryPoint> GetDeliveryPoints()
        {
            using (var context = new Data.SwiftDemoContext())
            {
                return context.Set<DeliveryPoint>().ToList();
            }
        }

        public void AddDeliveryPoint(DeliveryPoint deliveryPoint)
        {
            using (var context = new Data.SwiftDemoContext())
            {
                context.Set<DeliveryPoint>().Add(deliveryPoint);
                context.SaveChanges();
            }
        }

        public int AddDelivery(Delivery delivery)
        {
            using (var context = new Data.SwiftDemoContext())
            {
                context.Set<Delivery>().Add(delivery);
                context.SaveChanges();
                return delivery.ID;
            }
        }

        public Delivery GetDeliveryById(int deliveryId)
        {
            using (var context = new Data.SwiftDemoContext())
            {
                return context.Set<Delivery>().FirstOrDefault(dp => dp.ID == deliveryId);
            }
        }
    }
}
