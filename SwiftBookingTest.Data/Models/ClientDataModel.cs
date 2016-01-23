using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwiftBookingTest.Data.Models
{
    [Table("Clients")]
    public class ClientDataModel
    {
        [Key]
        public virtual Guid Id { get; set; }
        [Required]
        public virtual string Name { get; set; }
        [Required]
        public virtual string Phone { get; set; }
        [Required]
        public virtual string Address { get; set; }
    }
}
