using SwiftBookingTest.CoreContracts.BusinessEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwiftBookingTest.Model;
using SwiftBookingTest.CoreContracts;

namespace SwiftBookingTest.Core.BusinessEngine
{
    public class PhoneNumberBusinessEngine : IPhoneNumberBusinessEngine
    {
        private ISwiftDemoUow _uow;

        public PhoneNumberBusinessEngine()
        {

        }

        public PhoneNumberBusinessEngine(ISwiftDemoUow uow)
        {
            this._uow = uow;
        }
        public bool IsNumberValid(PhoneNumber number)
        {
            return number != null;
        }
    }
}
