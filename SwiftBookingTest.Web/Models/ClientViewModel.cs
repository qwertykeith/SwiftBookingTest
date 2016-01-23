using System;
using System.ComponentModel.DataAnnotations;

namespace SwiftBookingTest.Web.Models
{
    public class ClientViewModel
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [Required]        
        public string Address { get; set; }
    }
}
