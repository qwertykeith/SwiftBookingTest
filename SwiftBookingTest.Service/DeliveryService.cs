using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwiftBookingTest.Domain;
using SwiftBookingTest.DataAccess.DataStore;
using SwiftBookingTest.DataAccess;
using SwiftBookingTest.DataAccess.Entities;

namespace SwiftBookingTest.Service
{
    public class DeliveryService : IDeliveryService
    {
        /// <summary>
        /// Persist the details 
        /// </summary>
        /// <param name="details">Some delivery details that need saving</param>
        public void SaveDeliveryDetails(DeliveryDetailsDomain details)
        {
            using (DeliveryContext context = new DeliveryContext())
            {
                DeliveryDetails detailsToSave = new DeliveryDetails
                {
                    Name = details.Name,
                    Address = details.Address,
                    Phone = details.Phone
                };

                DeliveryStore dataStore = new DeliveryStore(context);
                dataStore.SaveDeliveryDetails(detailsToSave);
                context.SaveChanges();
            }
        }

        public List<DeliveryDetailsDomain> GetStuffThatHasBeenDelivered()
        {
            List<DeliveryDetailsDomain> result = new List<DeliveryDetailsDomain>();

            using (DeliveryContext context = new DeliveryContext())
            {
                foreach (var val in context.Deliveries)
                {
                    result.Add( new DeliveryDetailsDomain
                    {
                        DeliveryId = val.Id,
                        Name = val.Name,
                        Address = val.Address,
                        Phone = val.Phone
                    });

                }
            }

            return result;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~DeliveryService() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }

        #endregion
    }
}
