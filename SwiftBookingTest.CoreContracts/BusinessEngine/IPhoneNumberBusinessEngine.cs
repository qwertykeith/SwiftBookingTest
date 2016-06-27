using SwiftBookingTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftBookingTest.CoreContracts.BusinessEngine
{
    public interface IPhoneNumberBusinessEngine : IBusinessEngine
    {
        bool IsNumberValid(PhoneNumber number);
    }
}
