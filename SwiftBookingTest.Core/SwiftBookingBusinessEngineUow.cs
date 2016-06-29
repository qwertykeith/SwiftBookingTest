using SwiftBookingTest.CoreContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwiftBookingTest.CoreContracts.BusinessEngine;
using SwiftBookingTest.Core.Helpers;
using SwiftBookingTest.Core.BusinessEngine;

namespace SwiftBookingTest.Core
{
    public class SwiftBookingBusinessEngineUow : ISwiftBookingBusinessEngineUow, IDisposable
    {
        protected IBusinessEngineFactory BusinessProvider { get; set; }

        public SwiftBookingBusinessEngineUow(IBusinessEngineFactory businessEngineFactory)
        {
            BusinessProvider = businessEngineFactory;
        }

        public IClientRecordsBusinessEngine ClientRecordBusinessValidatiors
        {
            get
            {
                return BusinessProvider.GetBusinessEngine<ClientRecordsBusinessEngine>();
            }
        }

        public IPhoneNumberBusinessEngine PhoneNumberBusinessValidatiors
        {
            get
            {
                return BusinessProvider.GetBusinessEngine<PhoneNumberBusinessEngine>();
            }
        }


        #region IDisposable

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }



        #endregion
    }
}
