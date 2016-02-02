using System;
using System.ComponentModel.DataAnnotations;

namespace SwiftBookingTest.Web.Models
{
    public class ClientRecord
    {
        [Key]
        public Guid? Id { get; private set; }
        public string Name { get; private set; }
        public string Address { get; private set; }
        public string Phone { get; private set; }
        public bool IsBooked { get; private set; }

        protected ClientRecord()
        {
        }

        public ClientRecord(string name, string address, string phone)
        {
            Id = Guid.NewGuid();
            Name = name;
            Address = address;
            Phone = phone;
        }

        public void Book()
        {
            IsBooked = true;
        }
    }
}