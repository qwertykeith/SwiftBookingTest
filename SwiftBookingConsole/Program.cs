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
            GetCustomerWhereNameContainsLetter("a");

            DeleteBhanuPhoneRecord();

            AddBhanuPhones();

            GetClientWherePhoneNumberIsRepeatedMoreThanTwice();
        }
        /// <summary>
        /// Gets the customer where name contains letter.
        /// </summary>
        /// <param name="letters">The letters.</param>
        private static void GetCustomerWhereNameContainsLetter(string letters)
        {
            using (var Uow = new SwiftDemoUow(new RepositoryProvider(new RepositoryFactories())))
            {
                var clients = Uow.ClientRecords.GetAll().Where(x => x.Name.ToLower().Contains(letters)).ToList();
            }
        }

        private static void GetClientWherePhoneNumberIsRepeatedMoreThanTwice()
        {
            using (var Uow = new SwiftDemoUow(new RepositoryProvider(new RepositoryFactories())))
            {


                var clients = Uow.ClientRecords.GetAll().Include(x => x.ClientPhones.Select(y => y.PhoneNumber));
                var pp = clients.Where(z => z.ClientPhones
                    .GroupBy(x => x.PhoneNumber.Number)
                    .Select(c => c.Count()).Any(y => y > 2))
                    .ToList();

                Console.ReadLine();
            }
        }

        private static void AddBhanuPhones()
        {
            using (var Uow = new SwiftDemoUow(new RepositoryProvider(new RepositoryFactories())))
            {
                var clients = Uow.ClientRecords.GetAll().Include(x => x.ClientPhones.Select(y => y.PhoneNumber)).Where(x => x.Id == 3).First();
                clients.ClientPhones.Add(new ClientPhone
                {
                    ClientRecord = clients,
                    PhoneNumber = new PhoneNumber { Number = "55555" }
                });
                clients.ClientPhones.Add(new ClientPhone
                {
                    ClientRecord = clients,
                    PhoneNumber = new PhoneNumber { Number = "22222" }
                });
                clients.Address = "W";
                Uow.Commit();
            }
        }

        private static void DeleteBhanuPhoneRecord()
        {
            //under the hood in both delete method executes each delete command individually

            using (var Uow = new SwiftDemoUow(new RepositoryProvider(new RepositoryFactories())))
            {
                var clients = Uow.ClientRecords.GetAll().Include(x => x.ClientPhones.Select(y => y.PhoneNumber)).Where(x => x.Id == 3).First();
                var newList = clients.ClientPhones.ToList();
                //newList.ForEach((x) =>
                //{
                //    Uow.PhoneNumbers.Delete(x.PhoneNumber);
                //    Uow.ClientPhones.Delete(x);
                //});
                Uow.PhoneNumbers.DeleteByIds(newList.Select(v => v.PhoneNumber));
                Uow.ClientPhones.DeleteByIds(newList);
                Uow.Commit();
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

        private static void AddClient(SwiftDemoUow Uow)
        {
            var client = new ClientRecord { Address = "12, Sanoor, Bali", Name = "Bhanu Sharma", ClientPhones = null };
            Uow.ClientRecords.Add(client);
            Uow.Commit();
        }
    }
}
