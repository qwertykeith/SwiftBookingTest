using SwiftBookingTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftBookingTest.Service.Contracts
{
    public interface IDeliveryService
    {
        List<Person> GetPersons();

        void AddPerson(Person person);

        Task<string> Book(Person pickup, Person dropoff);
    }
}
