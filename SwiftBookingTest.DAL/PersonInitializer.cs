using SwiftBookingTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftBookingTest.DAL
{ 
    public class PersonInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<PersonContext>
    {
        protected override void Seed(PersonContext context)
        {
            var persons = new List<Person>
            {
                new Person { Address = "123 Some address st, Melbourne, Australia" },
                new Person { Address = "123 Another address st, New York" },
                new Person { Address = "668 Joel St, Brisbane, Australia" },
            };
            persons.ForEach(p => context.Persons.Add(p));           
            context.SaveChanges();
        }
    }
}
