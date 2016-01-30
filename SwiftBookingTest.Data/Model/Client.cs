using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwiftBookingTest.Data.Model
{
    public class Client
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(500)]
        public string PickupAddress { get; set; }

        [Required]
        [StringLength(500)]
        public string DeliveryAddress { get; set; }

        [Required]
        [StringLength(50)]
        public string PrimaryPhone { get; set; }

        [Required]
        [StringLength(50)]
        public string BookingReference { get; set; }
    }
}
