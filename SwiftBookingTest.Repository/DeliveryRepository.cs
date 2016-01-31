using SwiftBookingTest.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwiftBookingTest.Model;
using SwiftBookingTest.DAL;

namespace SwiftBookingTest.Repository
{
    public class DeliveryRepository : IDeliveryRepository
    {
        private PersonContext db = new PersonContext();
        public PersonContext DbContext
        {
            get { return db; }
            set { db = value; }
        }

        public void AddPerson(Person person)
        {
            if (person != null)
            {
                var dbPerson = db.Persons.Where(p => p.Address == person.Address).FirstOrDefault();
                if (dbPerson == null)
                {
                    db.Persons.Add(person);
                }
                else
                {
                    dbPerson.Name = person.Name;
                    dbPerson.Phone = person.Phone;
                    dbPerson.Address = person.Address;
                }
                db.SaveChanges();
            }
        }

        public List<Person> GetPerons()
        {
            return db.Persons.ToList();
        }
    }
}
