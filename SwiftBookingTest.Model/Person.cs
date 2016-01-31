using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftBookingTest.Model
{
    public class Person
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        [Required, MaxLength(200)]
        public string Address { get; set; }
    }
}
