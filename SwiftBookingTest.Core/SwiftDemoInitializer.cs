﻿using SwiftBookingTest.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftBookingTest.Core
{
    /// <summary>
    /// Initialise databse on initialisation
    /// </summary>
    public class SwiftDemoInitializer : DropCreateDatabaseAlways<SwiftDemoContext>
    {
        protected override void Seed(SwiftDemoContext context)
        {
            InitialiseClientRecord(context);
        }

        /// <summary>
        /// Initialises the client records.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        private void InitialiseClientRecord(SwiftDemoContext context)
        {
            var clients = AddClientRecord(context);
            //clients.ForEach(b => context.ClientRecords.Add(b));
            //context.SaveChanges();
            var phones = AddPhoneNumbers(context);
            phones.ForEach(b => context.PhoneNumber.Add(b));
            //context.SaveChanges();
            clients[0].ClientPhones.Add(new ClientPhone { ClientRecordId = clients[0].Id, PhoneNumberId = phones[0].Id });
            clients[0].ClientPhones.Add(new ClientPhone { ClientRecordId = clients[0].Id, PhoneNumberId = phones[1].Id });

            clients[1].ClientPhones.Add(new ClientPhone { ClientRecordId = clients[1].Id, PhoneNumberId = phones[2].Id });
            clients[1].ClientPhones.Add(new ClientPhone { ClientRecordId = clients[1].Id, PhoneNumberId = phones[3].Id });
            //context.SaveChanges();
            clients.ForEach(b => context.ClientRecords.Add(b));
            SetInstructorsWithCoarse(context);
            
            base.Seed(context);
        }

        private static void SetInstructorsWithCoarse(SwiftDemoContext context)
        {
            var instructors = new List<Instructor>
            {
                new Instructor
                {
                    LastName = "Sharma",
                    FirstName = "Bhanu",
                    HireDate = DateTime.Now,
                    Coarses =new List<Coarse>
                    {
                        new Coarse { CourseName="Net"},
                    }
                },
                new Instructor
                {
                    LastName = "Sharma",
                    FirstName = "Sonia",
                    HireDate = DateTime.Now,
                    Coarses =new List<Coarse>
                    {
                        new Coarse { CourseName="C"},
                    }
                },
                new Instructor
                {
                    LastName = "Chaudhary",
                    FirstName = "Atul",
                    HireDate = DateTime.Now,
                    Coarses =new List<Coarse>
                    {
                        new Coarse { CourseName="Java"},
                        new Coarse { CourseName="c++"},
                        new Coarse { CourseName="C"},
                        new Coarse { CourseName="JavaScript"},
                        new Coarse { CourseName="HTML5"},
                        new Coarse { CourseName="CSS3"},
                    }
                },
                new Instructor
                {
                    LastName = "Chaudhary",
                    FirstName = "Kapil",
                    HireDate = DateTime.Now,
                    Coarses =new List<Coarse>
                    {
                        new Coarse { CourseName="C++"},
                    }
                }
            };

            instructors.ForEach(b => context.Instructors.Add(b));
        }

        /// <summary>
        /// Adds the phone numbers.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        private List<PhoneNumber> AddPhoneNumbers(SwiftDemoContext context)
        {
            var list = new List<PhoneNumber>
            {
                new PhoneNumber {Number="0431209256",Id=1 },
                new PhoneNumber {Number="0432999215",Id=2 },
                new PhoneNumber {Number="0420445210",Id=3 },
                new PhoneNumber {Number="0435099500",Id=4 }
            };
            //list.ForEach(b => context.PhoneNumber.Add(b));
            //base.Seed(context);
            return list;
        }
        /// <summary>
        /// Adds the client record.
        /// </summary>
        /// <returns></returns>
        private static List<ClientRecord> AddClientRecord(SwiftDemoContext context)
        {
            var list = new List<ClientRecord> {
                new ClientRecord {Name="Atul",Address="18 Brunel Drive, Modbury Heihts, Adelaide",Id=1
                }, new ClientRecord {
                    Name="John",Address="282 Kingfisher street, Somehwre, Melbourne",Id=2
                }
            };
            //list.ForEach(b => context.ClientRecords.Add(b));
            //base.Seed(context);
            return list;
        }
    }
}
