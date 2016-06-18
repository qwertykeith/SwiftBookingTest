using SwiftBookingTest.Core;
using SwiftBookingTest.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using SwiftBookingTest.Model;

namespace SwiftBookingConsole
{
    class Program
    {

        static void Main(string[] args)
        {
            GetClient();
        }

        private static void GetClient()
        {
            using (var Uow = new SwiftDemoUow(new RepositoryProvider(new RepositoryFactories())))
            {
                var clients = Uow.ClientRecords.GetAll().Include(x => x.ClientPhones.Select(y => y.PhoneNumber)).ToList();
                //Add(Uow, clients);


                var pp = clients.Where(x => x.ClientPhones.GroupBy(y => y.PhoneNumber.Number)
                .Count() > 2).SelectMany(z => z.ClientPhones).First();

                Console.ReadLine();
            }
        }

        private static void Add(SwiftDemoUow Uow, List<ClientRecord> clients)
        {
            var firstClient = clients[0];
            firstClient.ClientPhones.Add(new ClientPhone
            {
                ClientRecord = firstClient,
                PhoneNumber = new PhoneNumber { Number = "999999999" },
            });
            var firstClientPone = firstClient.ClientPhones.ToList()[0];
            firstClientPone.PhoneNumber.Number = "00000000000";
            Uow.Commit();
        }
    }
}
