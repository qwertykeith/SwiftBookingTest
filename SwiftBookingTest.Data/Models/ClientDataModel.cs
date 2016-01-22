using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
