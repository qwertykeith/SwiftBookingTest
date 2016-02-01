using SwiftBookingTest.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwiftBookingTest.Model;
using SwiftBookingTest.Repository.Contracts;
using System.Configuration;

namespace SwiftBookingTest.Service
{
    public class DeliveryService : IDeliveryService
    {
        private IDeliveryRepository repo;
        private static string MerchantKey = ConfigurationManager.AppSettings["MerchantKey"];

        public DeliveryService(IDeliveryRepository repo)
        {
            this.repo = repo;
        }

        public void AddPerson(Person person)
        {
            repo.AddPerson(person);
        }

        public async Task<string> Book(Person pickup, Person dropoff)
        {
            return await new SwiftAPI.DeliveryService(MerchantKey).BookSync(pickup, dropoff);
        }

        public List<Person> GetPersons()
        {
            return repo.GetPerons();
        }
    }
}
