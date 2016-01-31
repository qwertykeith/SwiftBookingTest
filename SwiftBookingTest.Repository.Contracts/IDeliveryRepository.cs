using SwiftBookingTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftBookingTest.Repository.Contracts
{
    public interface IDeliveryRepository
    {
        void AddPerson(Person person);

        List<Person> GetPerons();
    }
}
